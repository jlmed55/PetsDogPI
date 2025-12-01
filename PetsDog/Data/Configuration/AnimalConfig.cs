using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetsDog.Models;

namespace PetsDog.Data.Configuration
{
    public class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.id_animal);

            builder
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.Id_cliente)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
