namespace TransitoDB.Domain.Entities
{
    public class Agente
    {
        public int AgenteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Matricula { get; set; }
        public int? UnidadId { get; set; }
        public bool Activo { get; set; }

        // Relaciones
        public Empleado Empleado { get; set; }
        public Unidad Unidad { get; set; }
        public ICollection<Multa> Multas { get; set; }
    }
}

