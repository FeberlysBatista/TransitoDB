using AutoMapper;

using TransitoDB.Application.DTOs;
using TransitoDB.Domain.Entities;

namespace Transitodb.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo de entidades a DTOs
            CreateMap<Cargo, CargoDto>();
            CreateMap<Unidad, UnidadDto>();
            CreateMap<TipoInfraccion, TipoInfraccionDto>();
            CreateMap<Persona, PersonaDto>();
            CreateMap<Empleado, EmpleadoDto>();
            CreateMap<Agente, AgenteDto>();
            CreateMap<Conductor, ConductorDto>();
            CreateMap<Vehiculo, VehiculoDto>();
            CreateMap<PropiedadVehiculo, PropiedadVehiculoDto>();

            CreateMap<Multa, MultaDto>()
                .ForMember(dest => dest.SaldoPendiente, opt => opt.Ignore())
                .AfterMap((src, dest) => {
                    decimal totalVigente = 0;
                    foreach (var detalle in src.MultaDetalles)
                    {
                        if (detalle.EstadoLinea == "Vigente")
                            totalVigente += (decimal)detalle.MontoLinea;
                    }
                    dest.SaldoPendiente = totalVigente - src.TotalPagado;
                });

            CreateMap<MultaDetalle, MultaDetalleDto>();
            CreateMap<Pago, PagoDto>();
            CreateMap<AplicacionPago, AplicacionPagoDto>();
            CreateMap<HistorialEstadoMulta, HistorialEstadoMultaDto>();

            // Mapeo de DTOs a entidades
            CreateMap<CargoDto, Cargo>();
            CreateMap<UnidadDto, Unidad>();
            CreateMap<TipoInfraccionDto, TipoInfraccion>();
            CreateMap<PersonaDto, Persona>();
            CreateMap<EmpleadoDto, Empleado>();
            CreateMap<AgenteDto, Agente>();
            CreateMap<ConductorDto, Conductor>();
            CreateMap<VehiculoDto, Vehiculo>();
            CreateMap<PropiedadVehiculoDto, PropiedadVehiculo>();

            CreateMap<MultaEmitirDto, Multa>();
            CreateMap<MultaDetalleDto, MultaDetalle>();
            CreateMap<PagoRegistrarDto, Pago>();
            CreateMap<PagoDto, Pago>();
            CreateMap<AplicacionPagoDto, AplicacionPago>();
            CreateMap<HistorialEstadoMultaDto, HistorialEstadoMulta>();
        }
    }
}