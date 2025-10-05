using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransitoDB.Application.DTOs;
using TransitoDB.Application.Interfaces.IAppServices;

namespace TransitoDB.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UnidadController : ControllerBase
    {
        private readonly IUnidadAppService _unidadAppService;

        public UnidadController(IUnidadAppService unidadAppService)
        {
            _unidadAppService = unidadAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UnidadDto>>> GetUnidades()
        {
            var unidades = await _unidadAppService.GetAllAsync();
            return Ok(unidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UnidadDto>> GetUnidad(int id)
        {
            var unidad = await _unidadAppService.GetByIdAsync(id);

            if (unidad == null)
            {
                return NotFound();
            }

            return Ok(unidad);
        }

        [HttpGet("provincia/{provincia}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UnidadDto>>> GetUnidadesByProvincia(string provincia)
        {
            var unidades = await _unidadAppService.GetByProvinciaAsync(provincia);
            return Ok(unidades);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<ActionResult<UnidadDto>> PostUnidad([FromBody] UnidadDto unidadDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unidad = await _unidadAppService.AddAsync(unidadDto);
            return CreatedAtAction(nameof(GetUnidad), new { id = unidad.UnidadId }, unidad);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<IActionResult> PutUnidad(int id, [FromBody] UnidadDto unidadDto)
        {
            if (id != unidadDto.UnidadId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _unidadAppService.UpdateAsync(unidadDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteUnidad(int id)
        {
            try
            {
                await _unidadAppService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}