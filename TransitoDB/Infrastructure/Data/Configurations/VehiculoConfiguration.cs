using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            builder.ToTable("Vehiculo");
            builder.HasKey(v => v.VehiculoId);

            builder.Property(v => v.Placa)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(v => v.VIN)
                .HasMaxLength(30);

            builder.Property(v => v.Marca)
                .HasMaxLength(60);

            builder.Property(v => v.Modelo)
                .HasMaxLength(60);

            builder.Property(v => v.Anio);

            builder.Property(v => v.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()");

            builder.HasIndex(v => v.Placa).IsUnique();
        }
    }
}