using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace PetsDog.Database
{
    public static class DatabaseBootstrapper
    {
        private static readonly string[] ExpectedTables =
        {
            "Clientes",
            "Profissionais",
            "Servicos",
            "Animals",
            "Agendamento"
        };

        public static async Task EnsureDatabaseAsync(
            IConfiguration configuration,
            ILogger logger,
            string contentRootPath)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                logger.LogWarning("Não foi possível criar o banco: string de conexão ausente.");
                return;
            }

            var connectionBuilder = new MySqlConnectionStringBuilder(connectionString);
            var databaseName = connectionBuilder.Database;

            if (string.IsNullOrWhiteSpace(databaseName))
            {
                logger.LogWarning("Não foi possível criar o banco: nome do banco não encontrado na connection string.");
                return;
            }

            connectionBuilder.Database = string.Empty;

            await using var connection = new MySqlConnection(connectionBuilder.ConnectionString);

            try
            {
                await connection.OpenAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Falha ao conectar ao servidor MySQL para criação do banco.");
                return;
            }

            if (await SchemaExistsAsync(connection, databaseName))
            {
                var hasAllTables = await HasAllTablesAsync(connection, databaseName);
                if (hasAllTables)
                {
                    logger.LogInformation("Banco de dados {DatabaseName} já existe com todas as tabelas esperadas.", databaseName);
                    return;
                }
            }

            var scriptPath = Path.Combine(contentRootPath, "Database", "petsdog_mysql_schema.sql");

            if (!File.Exists(scriptPath))
            {
                logger.LogWarning("Script de criação não encontrado em {ScriptPath}", scriptPath);
                return;
            }

            var scriptText = await File.ReadAllTextAsync(scriptPath);

            var script = new MySqlScript(connection, scriptText)
            {
                Delimiter = ";"
            };

            try
            {
                await script.ExecuteAsync();
                logger.LogInformation("Banco de dados {DatabaseName} criado/atualizado a partir do script {ScriptPath}", databaseName, scriptPath);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Falha ao executar o script SQL para criar o banco {DatabaseName}.", databaseName);
            }
        }

        private static async Task<bool> SchemaExistsAsync(MySqlConnection connection, string schemaName)
        {
            const string sql = "SELECT COUNT(*) FROM information_schema.schemata WHERE schema_name = @schemaName";
            await using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@schemaName", schemaName);
            var result = (long?)await command.ExecuteScalarAsync();
            return result.GetValueOrDefault() > 0;
        }

        private static async Task<bool> HasAllTablesAsync(MySqlConnection connection, string schemaName)
        {
            const string sql = "SELECT table_name FROM information_schema.tables WHERE table_schema = @schemaName";
            await using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@schemaName", schemaName);

            var existingTables = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                if (reader[0] is string tableName)
                {
                    existingTables.Add(tableName);
                }
            }

            return ExpectedTables.All(existingTables.Contains);
        }
    }
}
