using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsDog.Models;
using System.Reflection.Emit;

namespace PetsDog.Data.Configuration
{
    public class AgendamentoConfig : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(a => a.id_agendamento);

            builder
                .HasOne(ag => ag.Animal)
                .WithMany(a => a.Agendamentos)
                .HasForeignKey(ag => ag.id_animal)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ag => ag.Servico)
                .WithMany()
                .HasForeignKey(ag => ag.id_servico)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ag => ag.Profissional)
                .WithMany()
                .HasForeignKey(ag => ag.id_profissional)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
