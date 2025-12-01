using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsDog.Models;

namespace PetsDog.Data.Configuration
{
    public class ServicoConfig : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.HasKey(s => s.Idservico);
        }
    }


}
