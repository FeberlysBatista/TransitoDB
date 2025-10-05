using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class ConductorConfiguration : IEntityTypeConfiguration<Conductor>
    {
        public void Configure(EntityTypeBuilder<Conductor> builder)
        {
            builder.ToTable("Conductor");
            builder.HasKey(c => c.ConductorId);

            builder.Property(c => c.Cedula)
                .HasMaxLength(20);

            builder.Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Apellido1)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Apellido2)
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .HasMaxLength(200);

            builder.Property(c => c.Telefono)
                .HasMaxLength(30);

            builder.Property(c => c.Direccion)
                .HasMaxLength(300);

            builder.Property(c => c.LicenciaNro)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.LicenciaClase)
                .HasMaxLength(10);

            builder.Property(c => c.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()");

            builder.HasIndex(c => c.Cedula).IsUnique().HasFilter("[Cedula] IS NOT NULL");
            builder.HasIndex(c => c.LicenciaNro).IsUnique();
        }
    }
}