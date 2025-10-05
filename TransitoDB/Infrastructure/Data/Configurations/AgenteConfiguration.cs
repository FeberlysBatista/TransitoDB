using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class AgenteConfiguration : IEntityTypeConfiguration<Agente>
    {
        public void Configure(EntityTypeBuilder<Agente> builder)
        {
            builder.ToTable("Agente");
            builder.HasKey(a => a.AgenteId);

            builder.Property(a => a.Matricula)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasIndex(a => a.Matricula).IsUnique();
            builder.HasIndex(a => a.EmpleadoId).IsUnique();
        }
    }
}