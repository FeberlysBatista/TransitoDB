using System;
using System.Collections.Generic;

namespace TransitoDB.Application.DTOs
{
    public class MultaEmitirDto
    {
        public string Folio { get; set; }
        public int ConductorId { get; set; }
        public int? VehiculoId { get; set; }
        public int AgenteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Localizacion { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public List<MultaDetalleDto> Detalles { get; set; }
    }

}