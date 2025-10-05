using System.Collections.Generic;

namespace TransitoDB.Application.DTOs
{
    public class ConductorDto
    {
        public int ConductorId { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string FechaNacimiento { get; set; }
        public string LicenciaNro { get; set; }
        public string LicenciaClase { get; set; }
        public string LicenciaVence { get; set; }
        public string FechaCreacion { get; set; }

        // Relaciones
        public virtual ICollection<MultaDto> Multas { get; set; }
        public virtual ICollection<PropiedadVehiculoDto> PropiedadesVehiculos { get; set; }
    }
}