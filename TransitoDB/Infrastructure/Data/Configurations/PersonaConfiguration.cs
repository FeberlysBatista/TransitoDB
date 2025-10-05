using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");
            builder.HasKey(p => p.PersonaId);

            builder.Property(p => p.Cedula)
                .HasMaxLength(20);

            builder.Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Apellido1)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Apellido2)
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .HasMaxLength(200);

            builder.Property(p => p.Telefono)
                .HasMaxLength(30);

            builder.Property(p => p.Direccion)
                .HasMaxLength(300);

            builder.Property(p => p.FechaCreacion)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()");

            builder.HasIndex(p => p.Cedula).IsUnique().HasFilter("[Cedula] IS NOT NULL");
        }
    }
}