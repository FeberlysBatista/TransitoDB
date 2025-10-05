namespace TransitoDB.Domain.Entities
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public string Nombre { get; set; }

        // Relaciones
        public ICollection<Empleado> Empleados { get; set; }
    }
}
