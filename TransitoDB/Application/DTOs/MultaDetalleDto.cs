using System.Collections.Generic;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class MultaDetalleDto
    {
        public long MultaDetalleId { get; set; }
        public long MultaId { get; set; }
        public int TipoInfraccionId { get; set; }
        public int Cantidad { get; set; }
        public decimal MontoUnitario { get; set; }
        public decimal MontoLinea { get; set; }
        public string EstadoLinea { get; set; }

        // Relaciones
        public virtual MultaDto Multa { get; set; }
        public virtual TipoInfraccionDto TipoInfraccion { get; set; }
        public virtual ICollection<AplicacionPagoDto> AplicacionesPago { get; set; }
    }
}