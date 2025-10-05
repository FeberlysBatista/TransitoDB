namespace TransitoDB.Domain.Entities
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public string? VIN { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public short? Anio { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public ICollection<Multa> Multas { get; set; } = new List<Multa>();
        public ICollection<PropiedadVehiculo> Propiedades { get; set; } = new List<PropiedadVehiculo>();
        //                               
    }
}
