using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class MultaDetalleConfiguration : IEntityTypeConfiguration<MultaDetalle>
    {
        public void Configure(EntityTypeBuilder<MultaDetalle> builder)
        {
            builder.ToTable("MultaDetalle");
            builder.HasKey(md => md.MultaDetalleId);

            builder.Property(md => md.Cantidad)
                .IsRequired();

            builder.Property(md => md.MontoUnitario)
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(md => md.MontoLinea)
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(md => md.EstadoLinea)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("Vigente");

            builder.HasIndex(md => md.MultaId);
        }
    }
}