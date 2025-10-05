using Microsoft.EntityFrameworkCore;
using TransitoDB.Domain.Entities;

namespace TransitoDB.Infrastructure.Data
{
    public class TransitoDbContext : DbContext
    {
        public TransitoDbContext(DbContextOptions<TransitoDbContext> options) : base(options) { }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
        public DbSet<TipoInfraccion> TipoInfracciones { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<PropiedadVehiculo> PropiedadVehiculos { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<MultaDetalle> MultaDetalles { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<AplicacionPago> AplicacionPagos { get; set; }
        public DbSet<HistorialEstadoMulta> HistorialEstadoMultas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cargo>().ToTable("Cargo");
            modelBuilder.Entity<Unidad>().ToTable("Unidad");
            modelBuilder.Entity<TipoInfraccion>().ToTable("TipoInfraccion");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Empleado>().ToTable("Empleado");               // <— clave del error
            modelBuilder.Entity<Agente>().ToTable("Agente");
            modelBuilder.Entity<Conductor>().ToTable("Conductor");
            modelBuilder.Entity<Vehiculo>().ToTable("Vehiculo");
            modelBuilder.Entity<PropiedadVehiculo>().ToTable("PropiedadVehiculo");
            modelBuilder.Entity<Multa>().ToTable("Multa");
            modelBuilder.Entity<MultaDetalle>().ToTable("MultaDetalle");
            modelBuilder.Entity<Pago>().ToTable("Pago");
            modelBuilder.Entity<AplicacionPago>().ToTable("AplicacionPago");
            modelBuilder.Entity<HistorialEstadoMulta>().ToTable("HistorialEstadoMulta");


            // ==== Multa -> Conductor/Vehiculo/Agente ====
            modelBuilder.Entity<Multa>()
                .HasOne(m => m.Conductor)
                .WithMany(c => c.Multas)
                .HasForeignKey(m => m.ConductorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Multa>()
                .HasOne(m => m.Vehiculo)
                .WithMany(v => v.Multas)
                .HasForeignKey(m => m.VehiculoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Multa>()
                .HasOne(m => m.Agente)
                .WithMany(a => a.Multas)
                .HasForeignKey(m => m.AgenteId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==== MultaDetalle -> Multa / TipoInfraccion ====

            modelBuilder.Entity<MultaDetalle>()
             .HasOne(md => md.Multa)
             .WithMany(m => m.MultaDetalles)
             .HasForeignKey(md => md.MultaId)
             .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<MultaDetalle>()
                .HasOne(md => md.TipoInfraccion)
                .WithMany(ti => ti.MultaDetalles)
                .HasForeignKey(md => md.TipoInfraccionId)
                .OnDelete(DeleteBehavior.Restrict);

            // ==== Pago -> Multa ====
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Multa)
                .WithMany(m => m.Pagos)
                .HasForeignKey(p => p.MultaId)
                .OnDelete(DeleteBehavior.Cascade);

            // ==== AplicacionPago -> Pago / MultaDetalle ====
            // Usamos genéricos para NO exigir que AplicacionPago tenga las propiedades de navegación
            modelBuilder.Entity<AplicacionPago>()
             .HasOne(ap => ap.Pago)
             .WithMany(p => p.AplicacionesPago)
             .HasForeignKey(ap => ap.PagoId)
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AplicacionPago>()
             .HasOne(ap => ap.MultaDetalle)
             .WithMany(md => md.AplicacionesPago)
              .HasForeignKey(ap => ap.MultaDetalleId)
              .OnDelete(DeleteBehavior.Cascade);
            // ==== HistorialEstadoMulta -> Multa ====
            // using Microsoft.EntityFrameworkCore;
            // ...
            modelBuilder.Entity<HistorialEstadoMulta>(e =>
            {
                e.HasKey(h => h.HistorialId);
                e.HasOne(h => h.Multa)
                 .WithMany(m => m.HistorialEstados)
                 .HasForeignKey(h => h.MultaId)
                 .OnDelete(DeleteBehavior.Cascade);
            });


            // ==== PropiedadVehiculo (composite key) ====
            modelBuilder.Entity<PropiedadVehiculo>()
                .HasKey(pv => new { pv.VehiculoId, pv.ConductorId, pv.Desde });

            modelBuilder.Entity<PropiedadVehiculo>()
                .HasOne(pv => pv.Vehiculo)
                .WithMany(v => v.Propiedades)     // <-- coincide con tu entidad Vehiculo (Propiedades)
                .HasForeignKey(pv => pv.VehiculoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PropiedadVehiculo>()
                .HasOne(pv => pv.Conductor)
                .WithMany(c => c.PropiedadesVehiculos) // <-- coincide con tu entidad Conductor (PropiedadesVehiculo)
                .HasForeignKey(pv => pv.ConductorId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            // TipoInfraccion
            modelBuilder.Entity<TipoInfraccion>()
                .Property(t => t.MontoBase)
                .HasPrecision(12, 2);

            // Multa
            modelBuilder.Entity<Multa>()
                .Property(m => m.TotalPagado)
                .HasPrecision(12, 2);

            // MultaDetalle
            modelBuilder.Entity<MultaDetalle>()
                .Property(md => md.MontoUnitario)
                .HasPrecision(12, 2);

            modelBuilder.Entity<MultaDetalle>()
                .Property(md => md.MontoLinea)
                .HasPrecision(12, 2)
                .HasComputedColumnSql("[Cantidad] * [MontoUnitario]", stored: true); // coincide con PERSISTED

            // Pago
            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasPrecision(12, 2);

            // AplicacionPago
            modelBuilder.Entity<AplicacionPago>()
                .Property(ap => ap.MontoAplicado)
                .HasPrecision(12, 2);

        }
    }
}
