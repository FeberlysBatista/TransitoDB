using System.Collections.Generic;

namespace TransitoDB.Application.DTOs
{
    public class CargoDto
    {
        public int CargoId { get; set; }
        public string Nombre { get; set; }

        // Relaciones
        public virtual ICollection<EmpleadoDto> Empleados { get; set; }
    }
}