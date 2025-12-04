using Microsoft.EntityFrameworkCore;
using PetsDog.Data.Configuration;
using PetsDog.Models;

namespace PetsDog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) :
            base(options)
        { }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalConfig());
            modelBuilder.ApplyConfiguration(new AgendamentoConfig());
            modelBuilder.ApplyConfiguration(new CLienteConfig());
            modelBuilder.ApplyConfiguration(new ServicoConfig());
            modelBuilder.ApplyConfiguration(new ProfissionalConfig());
        }
    }
}
