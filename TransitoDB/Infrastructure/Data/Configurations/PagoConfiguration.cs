using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class PagoConfiguration : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pago");
            builder.HasKey(p => p.PagoId);

            builder.Property(p => p.Fecha)
                .IsRequired()
                .HasDefaultValueSql("SYSDATETIME()");

            builder.Property(p => p.Monto)
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(p => p.Medio)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Referencia)
                .HasMaxLength(60);

            builder.Property(p => p.Observaciones)
                .HasMaxLength(300);

            builder.HasIndex(p => p.MultaId);
        }
    }
}