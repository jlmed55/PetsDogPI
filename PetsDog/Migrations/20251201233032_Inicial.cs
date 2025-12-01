using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetsDog.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Idcliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Datacadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Idcliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    id_profissional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especialidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisponibilidadeInicio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiponibilidadeFim = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.id_profissional);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    Idservico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    duracao_min = table.Column<int>(type: "int", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.Idservico);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    id_animal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especie = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Porte = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Id_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.id_animal);
                    table.ForeignKey(
                        name: "FK_Animals_Clientes_Id_cliente",
                        column: x => x.Id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "Idcliente",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    id_agendamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_hora = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_animal = table.Column<int>(type: "int", nullable: false),
                    id_servico = table.Column<int>(type: "int", nullable: false),
                    id_profissional = table.Column<int>(type: "int", nullable: false),
                    Profissionalid_profissional = table.Column<int>(type: "int", nullable: true),
                    ServicoIdservico = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.id_agendamento);
                    table.ForeignKey(
                        name: "FK_Agendamento_Animals_id_animal",
                        column: x => x.id_animal,
                        principalTable: "Animals",
                        principalColumn: "id_animal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Profissionais_Profissionalid_profissional",
                        column: x => x.Profissionalid_profissional,
                        principalTable: "Profissionais",
                        principalColumn: "id_profissional");
                    table.ForeignKey(
                        name: "FK_Agendamento_Profissionais_id_profissional",
                        column: x => x.id_profissional,
                        principalTable: "Profissionais",
                        principalColumn: "id_profissional",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamento_Servicos_ServicoIdservico",
                        column: x => x.ServicoIdservico,
                        principalTable: "Servicos",
                        principalColumn: "Idservico");
                    table.ForeignKey(
                        name: "FK_Agendamento_Servicos_id_servico",
                        column: x => x.id_servico,
                        principalTable: "Servicos",
                        principalColumn: "Idservico",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_id_animal",
                table: "Agendamento",
                column: "id_animal");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_id_profissional",
                table: "Agendamento",
                column: "id_profissional");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_id_servico",
                table: "Agendamento",
                column: "id_servico");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_Profissionalid_profissional",
                table: "Agendamento",
                column: "Profissionalid_profissional");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_ServicoIdservico",
                table: "Agendamento",
                column: "ServicoIdservico");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_Id_cliente",
                table: "Animals",
                column: "Id_cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
