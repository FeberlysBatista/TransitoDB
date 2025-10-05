namespace TransitoDB.Domain.Entities
{
    public class Pago
    {
        public long PagoId { get; set; }
        public long MultaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Medio { get; set; }
        public string? Referencia { get; set; }
        public string? Observaciones { get; set; }

        // Relaciones
        public Multa Multa { get; set; }
        public ICollection<AplicacionPago> AplicacionesPago { get; set; } = new List<AplicacionPago>();
    }
}

