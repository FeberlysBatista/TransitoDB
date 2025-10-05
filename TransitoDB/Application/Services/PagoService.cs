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
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly IMapper _mapper;

        public PagoService(IPagoRepository pagoRepository, IMapper mapper)
        {
            _pagoRepository = pagoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pago>> GetAllAsync()
        {
            return await _pagoRepository.GetAllAsync();
        }

        public async Task<Pago> GetByIdAsync(long id)
        {
            return await _pagoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pago>> GetByMultaIdAsync(long multaId)
        {
            return await _pagoRepository.GetByMultaIdAsync(multaId);
        }

        public async Task<Pago> AddAsync(Pago pago)
        {
            await _pagoRepository.AddAsync(pago);
            await _pagoRepository.SaveChangesAsync();
            return pago;
        }

        public async Task UpdateAsync(Pago pago)
        {
            _pagoRepository.Update(pago);
            await _pagoRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var pago = await _pagoRepository.GetByIdAsync(id);
            if (pago != null)
            {
                _pagoRepository.Delete(pago);
                await _pagoRepository.SaveChangesAsync();
            }
        }
    }
}