using System.Collections.Generic;

namespace TransitoDB.Application.DTOs
{
    public class VehiculoDto
    {
        public int VehiculoId { get; set; }
        public string Placa { get; set; }
        public string VIN { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public short? Anio { get; set; }
        public string FechaCreacion { get; set; }

        // Relaciones
        public virtual ICollection<MultaDto> Multas { get; set; }
        public virtual ICollection<PropiedadVehiculoDto> PropiedadesVehiculos { get; set; }
    }
}