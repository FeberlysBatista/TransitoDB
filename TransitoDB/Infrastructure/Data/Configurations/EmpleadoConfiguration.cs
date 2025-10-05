using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleado");
            builder.HasKey(e => e.EmpleadoId);

            builder.Property(e => e.Documento)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Apellido1)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Apellido2)
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .HasMaxLength(200);

            builder.Property(e => e.Telefono)
                .HasMaxLength(30);

            builder.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(e => e.FechaAlta)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()");

            builder.HasIndex(e => e.Documento).IsUnique();
        }
    }
}