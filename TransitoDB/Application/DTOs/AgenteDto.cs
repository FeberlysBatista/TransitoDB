using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class AgenteDto
    {
        public int AgenteId { get; set; }
        public int EmpleadoId { get; set; }
        public string Matricula { get; set; }
        public int? UnidadId { get; set; }
        public bool Activo { get; set; }

        // Relaciones
        public virtual EmpleadoDto Empleado { get; set; }
        public virtual UnidadDto Unidad { get; set; }
        public virtual ICollection<MultaDto> Multas { get; set; }
    }
}