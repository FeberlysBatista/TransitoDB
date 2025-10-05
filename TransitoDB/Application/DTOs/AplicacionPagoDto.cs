using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class AplicacionPagoDto
    {
        public long AplicacionPagoId { get; set; }
        public long PagoId { get; set; }
        public long MultaDetalleId { get; set; }
        public decimal MontoAplicado { get; set; }

        // Relaciones
        public virtual PagoDto Pago { get; set; }
        public virtual MultaDetalleDto MultaDetalle { get; set; }
    }
}