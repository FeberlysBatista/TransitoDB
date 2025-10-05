using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data.Configurations
{
    public class UnidadConfiguration : IEntityTypeConfiguration<Unidad>
    {
        public void Configure(EntityTypeBuilder<Unidad> builder)
        {
            builder.ToTable("Unidad");
            builder.HasKey(u => u.UnidadId);

            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(120);

            builder.Property(u => u.Provincia)
                .HasMaxLength(80);

            builder.Property(u => u.Municipio)
                .HasMaxLength(80);
        }
    }
}