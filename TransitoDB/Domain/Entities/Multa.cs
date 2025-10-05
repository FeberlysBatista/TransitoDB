using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TransitoDB.Domain.Entities
{
    public class Multa
    {
        public long MultaId { get; set; }
        public string Folio { get; set; }
        public int ConductorId { get; set; }
        public int? VehiculoId { get; set; }
        public int AgenteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string? Localizacion { get; set; }
        public string? Observaciones { get; set; }
        public string Estado { get; set; }
        public decimal TotalPagado { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public Conductor Conductor { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public Agente Agente { get; set; }
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public ICollection<MultaDetalle> MultaDetalles { get; set; } = new List<MultaDetalle>();
        public ICollection<HistorialEstadoMulta> HistorialEstados { get; set; } = new List<HistorialEstadoMulta>();
    }
}

