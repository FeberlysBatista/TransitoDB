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
    public class CargoAppService : ICargoAppService
    {
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;

        public CargoAppService(ICargoService cargoService, IMapper mapper)
        {
            _cargoService = cargoService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CargoDto>> GetAllAsync()
        {
            var cargos = await _cargoService.GetAllAsync();
            return _mapper.Map<IEnumerable<CargoDto>>(cargos);
        }

        public async Task<CargoDto> GetByIdAsync(int id)
        {
            var cargo = await _cargoService.GetByIdAsync(id);
            return _mapper.Map<CargoDto>(cargo);
        }

        public async Task<CargoDto> AddAsync(CargoDto cargoDto)
        {
            var cargo = _mapper.Map<Cargo>(cargoDto);
            var result = await _cargoService.AddAsync(cargo);
            return _mapper.Map<CargoDto>(result);
        }

        public async Task UpdateAsync(CargoDto cargoDto)
        {
            var cargo = _mapper.Map<Cargo>(cargoDto);
            await _cargoService.UpdateAsync(cargo);
        }

        public async Task DeleteAsync(int id)
        {
            await _cargoService.DeleteAsync(id);
        }
    }
}