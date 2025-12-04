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

            builder.Property(a => a.ClienteId)
                .IsRequired();

            builder.Property(a => a.PetId)
                .IsRequired();

            builder.Property(a => a.DataHora)
                .IsRequired();
        }
    }
}
