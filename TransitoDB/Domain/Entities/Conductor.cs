using System;
using System.Collections.Generic;

namespace TransitoDB.Domain.Entities
{
    public class Conductor
    {
        public int ConductorId { get; set; }
        public string? Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string LicenciaNro { get; set; }
        public string? LicenciaClase { get; set; }
        public DateTime? LicenciaVence { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relaciones
        public ICollection<Multa> Multas { get; set; } = new List<Multa>();
        public ICollection<PropiedadVehiculo> PropiedadesVehiculos { get; set; } = new List<PropiedadVehiculo>();
        //                                                     ^^^ ahora coincide con el mapeo
    }
}
