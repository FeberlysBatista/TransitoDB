using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class AplicacionPagoConfiguration : IEntityTypeConfiguration<AplicacionPago>
    {
        public void Configure(EntityTypeBuilder<AplicacionPago> builder)
        {
            builder.ToTable("AplicacionPago");
            builder.HasKey(ap => ap.AplicacionPagoId);

            builder.Property(ap => ap.MontoAplicado)
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.HasIndex(ap => ap.MultaDetalleId);
        }
    }
}