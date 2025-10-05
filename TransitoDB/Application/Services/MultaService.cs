using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IRepositories;
using TransitoDB.Domain.Interfaces.IServices;

namespace TransitoDB.Application.Services
{
    public class MultaService : IMultaService
    {
        private readonly IMultaRepository _multaRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MultaService(IMultaRepository multaRepository, IMapper mapper, IMediator mediator)
        {
            _multaRepository = multaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<Multa>> GetAllAsync()
        {
            return await _multaRepository.GetAllAsync();
        }

        public async Task<Multa> GetByIdAsync(long id)
        {
            return await _multaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Multa>> GetMultasByConductorAsync(int conductorId)
        {
            return await _multaRepository.GetMultasByConductorAsync(conductorId);
        }

        public async Task<Multa> GetMultaWithDetailsAsync(long multaId)
        {
            return await _multaRepository.GetMultaWithDetailsAsync(multaId);
        }

        public async Task<IEnumerable<Multa>> GetMultasConSaldoAsync()
        {
            return await _multaRepository.GetMultasConSaldoAsync();
        }

        public async Task<Multa> EmitirMultaAsync(Multa multa, IEnumerable<MultaDetalle> detalles)
        {
            var multaId = await _multaRepository.EmitirMultaAsync(multa, detalles);

            // Obtener la multa completa con sus detalles
            var multaCompleta = await _multaRepository.GetMultaWithDetailsAsync(multaId);

            // Publicar evento de dominio si es necesario
            await _mediator.Publish(new MultaEmitidaNotification { MultaId = multaId });

            return multaCompleta;
        }

        public async Task RegistrarPagoAsync(Pago pago)
        {
            await _multaRepository.RegistrarPagoAsync(pago);
        }

        public async Task AnularRenglonMultaAsync(long multaDetalleId, int agenteId, string motivo)
        {
            await _multaRepository.AnularRenglonMultaAsync(multaDetalleId, agenteId, motivo);
        }
    }

    public class MultaEmitidaNotification : INotification
    {
        public long MultaId { get; set; }
    }
}