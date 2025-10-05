using System.Collections.Generic;

namespace TransitoDB.Application.DTOs
{
    public class UnidadDto
    {
        public int UnidadId { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }

        // Relaciones
        public virtual ICollection<AgenteDto> Agentes { get; set; }
    }
}