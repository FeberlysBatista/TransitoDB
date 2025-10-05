using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class PropiedadVehiculoConfiguration : IEntityTypeConfiguration<PropiedadVehiculo>
    {
        public void Configure(EntityTypeBuilder<PropiedadVehiculo> builder)
        {
            builder.ToTable("PropiedadVehiculo");

            // Clave primaria compuesta
            builder.HasKey(pv => new { pv.VehiculoId, pv.ConductorId, pv.Desde });

            builder.Property(pv => pv.Desde)
                .IsRequired();

            builder.Property(pv => pv.Hasta);
        }
    }
}