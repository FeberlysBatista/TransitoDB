using System.Collections.Generic;

namespace TransitoDB.Application.DTOs
{
    public class TipoInfraccionDto
    {
        public int TipoInfraccionId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal MontoBase { get; set; }
        public int Puntos { get; set; }
        public bool EsGrave { get; set; }

        // Relaciones
        public virtual ICollection<MultaDetalleDto> MultaDetalles { get; set; }
    }
}