using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IServices;

namespace TransitoDB.Application.AppServices
{
    public class MultaAppService : IMultaAppService
    {
        private readonly IMultaService _multaService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MultaAppService(IMultaService multaService, IMapper mapper, IMediator mediator)
        {
            _multaService = multaService;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<MultaDto>> GetAllAsync()
        {
            var multas = await _multaService.GetAllAsync();
            return _mapper.Map<IEnumerable<MultaDto>>(multas);
        }

        public async Task<MultaDto> GetByIdAsync(long id)
        {
            var multa = await _multaService.GetByIdAsync(id);
            return _mapper.Map<MultaDto>(multa);
        }

        public async Task<IEnumerable<MultaDto>> GetMultasByConductorAsync(int conductorId)
        {
            var multas = await _multaService.GetMultasByConductorAsync(conductorId);
            return _mapper.Map<IEnumerable<MultaDto>>(multas);
        }

        public async Task<MultaDto> GetMultaWithDetailsAsync(long multaId)
        {
            var multa = await _multaService.GetMultaWithDetailsAsync(multaId);
            return _mapper.Map<MultaDto>(multa);
        }

        public async Task<IEnumerable<MultaDto>> GetMultasConSaldoAsync()
        {
            var multas = await _multaService.GetMultasConSaldoAsync();
            return _mapper.Map<IEnumerable<MultaDto>>(multas);
        }

        public async Task<MultaDto> EmitirMultaAsync(MultaEmitirDto multaEmitirDto)
        {
            // Validar que el agente esté autorizado
            // (Lógica de validación adicional aquí)

            var multa = _mapper.Map<Multa>(multaEmitirDto);
            var detalles = _mapper.Map<IEnumerable<MultaDetalle>>(multaEmitirDto.Detalles);

            var multaCompleta = await _multaService.EmitirMultaAsync(multa, detalles);

            // Publicar evento de dominio si es necesario
            await _mediator.Publish(new MultaEmitidaNotification { MultaId = multaCompleta.MultaId });

            return _mapper.Map<MultaDto>(multaCompleta);
        }

        public async Task<PagoDto> RegistrarPagoAsync(PagoRegistrarDto pagoDto)
        {
            var pago = _mapper.Map<Pago>(pagoDto);
            await _multaService.RegistrarPagoAsync(pago);

            // Obtener el pago actualizado con sus detalles
            // Aquí podrías implementar un método en el repositorio para obtener el pago con sus detalles
            return _mapper.Map<PagoDto>(pago);
        }

        public async Task AnularRenglonMultaAsync(long multaDetalleId, int agenteId, string motivo)
        {
            await _multaService.AnularRenglonMultaAsync(multaDetalleId, agenteId, motivo);
        }
    }

    public class MultaEmitidaNotification : INotification
    {
        public long MultaId { get; set; }
    }
}