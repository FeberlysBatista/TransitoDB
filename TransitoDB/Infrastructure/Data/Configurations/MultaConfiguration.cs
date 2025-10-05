using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class MultaConfiguration : IEntityTypeConfiguration<Multa>
    {
        public void Configure(EntityTypeBuilder<Multa> builder)
        {
            builder.ToTable("Multa");
            builder.HasKey(m => m.MultaId);

            builder.Property(m => m.Folio)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(m => m.Estado)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(m => m.TotalPagado)
                .HasColumnType("decimal(12,2)")
                .HasDefaultValue(0);

            builder.Property(m => m.FechaCreacion)
                .HasDefaultValueSql("SYSDATETIME()");

            builder.HasIndex(m => m.Folio).IsUnique();
            builder.HasIndex(m => m.ConductorId);
            builder.HasIndex(m => m.Estado);
        }
    }
}