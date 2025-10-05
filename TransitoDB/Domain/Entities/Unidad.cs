namespace TransitoDB.Domain.Entities
{
    public class Unidad
    {
        public int UnidadId { get; set; }
        public string Nombre { get; set; }
        public string? Provincia { get; set; }
        public string? Municipio { get; set; }

        // Relaciones
        public ICollection<Agente> Agentes { get; set; }
    }
}

