using System;
using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class HistorialEstadoMultaDto
    {
        public long HistorialId { get; set; }
        public long MultaId { get; set; }
        public string EstadoAnterior { get; set; }
        public string EstadoNuevo { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }

        // Relaciones
        public virtual MultaDto Multa { get; set; }
    }
}