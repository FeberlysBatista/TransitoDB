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
    public class MultaDetalleService : IMultaDetalleService
    {
        private readonly IMultaDetalleRepository _multaDetalleRepository;
        private readonly IMapper _mapper;

        public MultaDetalleService(IMultaDetalleRepository multaDetalleRepository, IMapper mapper)
        {
            _multaDetalleRepository = multaDetalleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MultaDetalle>> GetAllAsync()
        {
            return await _multaDetalleRepository.GetAllAsync();
        }

        public async Task<MultaDetalle> GetByIdAsync(long id)
        {
            return await _multaDetalleRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MultaDetalle>> GetByMultaIdAsync(long multaId)
        {
            return await _multaDetalleRepository.GetByMultaIdAsync(multaId);
        }

        public async Task<MultaDetalle> AddAsync(MultaDetalle multaDetalle)
        {
            await _multaDetalleRepository.AddAsync(multaDetalle);
            await _multaDetalleRepository.SaveChangesAsync();
            return multaDetalle;
        }

        public async Task UpdateAsync(MultaDetalle multaDetalle)
        {
            _multaDetalleRepository.Update(multaDetalle);
            await _multaDetalleRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var multaDetalle = await _multaDetalleRepository.GetByIdAsync(id);
            if (multaDetalle != null)
            {
                _multaDetalleRepository.Delete(multaDetalle);
                await _multaDetalleRepository.SaveChangesAsync();
            }
        }
    }
}