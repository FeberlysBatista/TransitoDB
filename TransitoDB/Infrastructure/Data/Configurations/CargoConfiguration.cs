using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("Cargo");
            builder.HasKey(c => c.CargoId);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(c => c.Nombre).IsUnique();
        }
    }
}