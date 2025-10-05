using System;
using System.Collections.Generic;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class PagoDto
    {
        public long PagoId { get; set; }
        public long MultaId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Medio { get; set; }
        public string Referencia { get; set; }
        public string Observaciones { get; set; }

        // Relaciones
        public virtual MultaDto Multa { get; set; }
        public virtual ICollection<AplicacionPagoDto> AplicacionesPago { get; set; }
    }
}