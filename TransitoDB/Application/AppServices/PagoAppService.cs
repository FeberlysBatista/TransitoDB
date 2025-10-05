using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;
using TransitoDB.Domain.Entities;
using TransitoDB.Domain.Interfaces.IServices;

namespace TransitoDB.Application.AppServices
{
    public class PagoAppService : IPagoAppService
    {
        private readonly IPagoService _pagoService;
        private readonly IMapper _mapper;

        public PagoAppService(IPagoService pagoService, IMapper mapper)
        {
            _pagoService = pagoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PagoDto>> GetAllAsync()
        {
            var pagos = await _pagoService.GetAllAsync();
            return _mapper.Map<IEnumerable<PagoDto>>(pagos);
        }

        public async Task<PagoDto> GetByIdAsync(long id)
        {
            var pago = await _pagoService.GetByIdAsync(id);
            return _mapper.Map<PagoDto>(pago);
        }

        public async Task<IEnumerable<PagoDto>> GetByMultaIdAsync(long multaId)
        {
            var pagos = await _pagoService.GetByMultaIdAsync(multaId);
            return _mapper.Map<IEnumerable<PagoDto>>(pagos);
        }

        public async Task<PagoDto> AddAsync(PagoDto pagoDto)
        {
            var pago = _mapper.Map<Pago>(pagoDto);
            var result = await _pagoService.AddAsync(pago);
            return _mapper.Map<PagoDto>(result);
        }

        public async Task UpdateAsync(PagoDto pagoDto)
        {
            var pago = _mapper.Map<Pago>(pagoDto);
            await _pagoService.UpdateAsync(pago);
        }

        public async Task DeleteAsync(long id)
        {
            await _pagoService.DeleteAsync(id);
        }
    }
}