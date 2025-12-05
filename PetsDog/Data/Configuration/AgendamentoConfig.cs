using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsDog.Models;

namespace PetsDog.Data.Configuration
{
    public class AgendamentoConfig : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(a => a.Id);

            builder.ToTable("Agendamentos");

            builder.Property(a => a.Id)
                .HasColumnName("id_agendamento");

            builder.Property(a => a.AnimalId)
                .HasColumnName("id_animal")
                .IsRequired();

            builder.Property(a => a.ServicoId)
                .HasColumnName("id_servico")
                .IsRequired();

            builder.Property(a => a.ProfissionalId)
                .HasColumnName("id_profissional")
                .IsRequired();

            builder.Property(a => a.DataHora)
                .HasColumnName("data_hora")
                .IsRequired();

            builder.Property(a => a.Status)
                .HasColumnName("status");

            builder
                .HasOne(a => a.Animal)
                .WithMany(an => an.Agendamentos)
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(a => a.Servico)
                .WithMany(s => s.Agendamentos)
                .HasForeignKey(a => a.ServicoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(a => a.Profissional)
                .WithMany(p => p.Agendamentos)
                .HasForeignKey(a => a.ProfissionalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
