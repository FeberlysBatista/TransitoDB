namespace TransitoDB.Domain.Entities
{
    public class MultaDetalle
    {

        public long MultaDetalleId { get; set; }
        public long MultaId { get; set; }
        public int TipoInfraccionId { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoUnitario { get; set; }
        public decimal? MontoLinea { get; set; }
        public string EstadoLinea { get; set; }

        // Relaciones
        public Multa Multa { get; set; }
        public TipoInfraccion TipoInfraccion { get; set; }
        public ICollection<AplicacionPago> AplicacionesPago { get; set; } = new List<AplicacionPago>();
    }

}

