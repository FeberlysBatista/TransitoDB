using AutoMapper;
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
    public class AplicacionPagoService : IAplicacionPagoService
    {
        private readonly IAplicacionPagoRepository _aplicacionPagoRepository;
        private readonly IMapper _mapper;

        public AplicacionPagoService(IAplicacionPagoRepository aplicacionPagoRepository, IMapper mapper)
        {
            _aplicacionPagoRepository = aplicacionPagoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AplicacionPago>> GetAllAsync()
        {
            return await _aplicacionPagoRepository.GetAllAsync();
        }

        public async Task<AplicacionPago> GetByIdAsync(long id)
        {
            return await _aplicacionPagoRepository.GetByIdAsync(id);
        }

        public async Task<decimal> GetTotalAplicadoByMultaDetalleIdAsync(long multaDetalleId)
        {
            return await _aplicacionPagoRepository.GetTotalAplicadoByMultaDetalleIdAsync(multaDetalleId);
        }

        public async Task<AplicacionPago> AddAsync(AplicacionPago aplicacionPago)
        {
            await _aplicacionPagoRepository.AddAsync(aplicacionPago);
            await _aplicacionPagoRepository.SaveChangesAsync();
            return aplicacionPago;
        }

        public async Task UpdateAsync(AplicacionPago aplicacionPago)
        {
            _aplicacionPagoRepository.Update(aplicacionPago);
            await _aplicacionPagoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var aplicacionPago = await _aplicacionPagoRepository.GetByIdAsync(id);
            if (aplicacionPago != null)
            {
                _aplicacionPagoRepository.Delete(aplicacionPago);
                await _aplicacionPagoRepository.SaveChangesAsync();
            }
        }
    }
}