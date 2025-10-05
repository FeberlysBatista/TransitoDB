namespace TransitoDB.Domain.Entities
{
    public class AplicacionPago
    {
        public long AplicacionPagoId { get; set; }
        public decimal MontoAplicado { get; set; }

        // FKs
        public long MultaDetalleId { get; set; }
        public long PagoId { get; set; }

        // Navegaciones requeridas por el Fluent API
        public Pago Pago { get; set; }
        public MultaDetalle MultaDetalle { get; set; }
    }
}
