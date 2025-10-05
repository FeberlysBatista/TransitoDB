using TransitoDB.Application.DTOs;

namespace TransitoDB.Application.DTOs
{
    public class PropiedadVehiculoDto
    {
        public int VehiculoId { get; set; }
        public int ConductorId { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }

        // Relaciones
        public virtual VehiculoDto Vehiculo { get; set; }
        public virtual ConductorDto Conductor { get; set; }
    }
}