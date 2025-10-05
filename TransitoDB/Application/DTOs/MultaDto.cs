using System;
using System.Collections.Generic;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class MultaDto
    {
        public long MultaId { get; set; }
        public string Folio { get; set; }
        public int ConductorId { get; set; }
        public int? VehiculoId { get; set; }
        public int AgenteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Localizacion { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public decimal TotalPagado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public decimal SaldoPendiente { get; set; }

        // Relaciones
        public virtual ConductorDto Conductor { get; set; }
        public virtual VehiculoDto Vehiculo { get; set; }
        public virtual AgenteDto Agente { get; set; }
        public virtual List<MultaDetalleDto> MultaDetalles { get; set; }
    }
}