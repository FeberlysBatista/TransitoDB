namespace TransitoDB.Domain.Entities
{
    public class PropiedadVehiculo
    {
        public int VehiculoId { get; set; }
        public int ConductorId { get; set; }
        public DateTime Desde { get; set; }
        public DateTime? Hasta { get; set; }

        // Relaciones
        public Vehiculo Vehiculo { get; set; }
        public Conductor Conductor { get; set; }
    }
}

