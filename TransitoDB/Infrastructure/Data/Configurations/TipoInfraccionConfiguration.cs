using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class TipoInfraccionConfiguration : IEntityTypeConfiguration<TipoInfraccion>
    {
        public void Configure(EntityTypeBuilder<TipoInfraccion> builder)
        {
            builder.ToTable("TipoInfraccion");
            builder.HasKey(ti => ti.TipoInfraccionId);

            builder.Property(ti => ti.Codigo)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(ti => ti.Descripcion)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(ti => ti.MontoBase)
                .HasColumnType("decimal(12,2)")
                .IsRequired();

            builder.Property(ti => ti.Puntos)
                .IsRequired();

            builder.Property(ti => ti.EsGrave)
                .IsRequired();

            builder.HasIndex(ti => ti.Codigo).IsUnique();
        }
    }
}