using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class EmpleadoDto
    {
        public int EmpleadoId { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int CargoId { get; set; }
        public bool Activo { get; set; }
        public string FechaAlta { get; set; }

        // Relaciones
        public virtual CargoDto Cargo { get; set; }
        public virtual AgenteDto Agente { get; set; }
    }
}