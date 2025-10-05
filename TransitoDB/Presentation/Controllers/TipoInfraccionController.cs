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
    public class TipoInfraccionController : ControllerBase
    {
        private readonly ITipoInfraccionAppService _tipoInfraccionAppService;

        public TipoInfraccionController(ITipoInfraccionAppService tipoInfraccionAppService)
        {
            _tipoInfraccionAppService = tipoInfraccionAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoInfraccionDto>>> GetTiposInfraccion()
        {
            var tiposInfraccion = await _tipoInfraccionAppService.GetAllAsync();
            return Ok(tiposInfraccion);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoInfraccionDto>> GetTipoInfraccion(int id)
        {
            var tipoInfraccion = await _tipoInfraccionAppService.GetByIdAsync(id);

            if (tipoInfraccion == null)
            {
                return NotFound();
            }

            return Ok(tipoInfraccion);
        }

        [HttpGet("codigo/{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoInfraccionDto>> GetTipoInfraccionByCodigo(string codigo)
        {
            var tipoInfraccion = await _tipoInfraccionAppService.GetByCodigoAsync(codigo);

            if (tipoInfraccion == null)
            {
                return NotFound();
            }

            return Ok(tipoInfraccion);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<TipoInfraccionDto>> PostTipoInfraccion([FromBody] TipoInfraccionDto tipoInfraccionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoInfraccion = await _tipoInfraccionAppService.AddAsync(tipoInfraccionDto);
            return CreatedAtAction(nameof(GetTipoInfraccion), new { id = tipoInfraccion.TipoInfraccionId }, tipoInfraccion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PutTipoInfraccion(int id, [FromBody] TipoInfraccionDto tipoInfraccionDto)
        {
            if (id != tipoInfraccionDto.TipoInfraccionId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _tipoInfraccionAppService.UpdateAsync(tipoInfraccionDto);
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
        public async Task<IActionResult> DeleteTipoInfraccion(int id)
        {
            try
            {
                await _tipoInfraccionAppService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}