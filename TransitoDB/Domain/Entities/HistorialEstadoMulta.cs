namespace TransitoDB.Domain.Entities
{
    public class HistorialEstadoMulta
    {
        public long HistorialId { get; set; }     
        public long MultaId { get; set; }         
        public string? EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public DateTime Fecha { get; set; }
        public string? Motivo { get; set; }

        public Multa Multa { get; set; }          // Relacion
    }
}
