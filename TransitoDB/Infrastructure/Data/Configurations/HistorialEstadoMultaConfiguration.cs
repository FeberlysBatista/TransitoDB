using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class HistorialEstadoMultaConfiguration : IEntityTypeConfiguration<HistorialEstadoMulta>
    {
        public void Configure(EntityTypeBuilder<HistorialEstadoMulta> builder)
        {
            builder.ToTable("HistorialEstadoMulta");
            builder.HasKey(h => h.HistorialId);

            builder.Property(h => h.EstadoAnterior)
                .HasMaxLength(30);

            builder.Property(h => h.EstadoNuevo)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(h => h.Fecha)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()");

            builder.Property(h => h.Motivo)
                .HasMaxLength(300);

            builder.HasIndex(h => h.MultaId);
        }
    }
}