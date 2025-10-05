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
    public class AgenteController : ControllerBase
    {
        private readonly IAgenteAppService _agenteAppService;

        public AgenteController(IAgenteAppService agenteAppService)
        {
            _agenteAppService = agenteAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAgentes()
        {
            var agentes = await _agenteAppService.GetAllAsync();
            return Ok(agentes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AgenteDto>> GetAgente(int id)
        {
            var agente = await _agenteAppService.GetByIdAsync(id);

            if (agente == null)
            {
                return NotFound();
            }

            return Ok(agente);
        }

        [HttpGet("matricula/{matricula}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AgenteDto>> GetAgenteByMatricula(string matricula)
        {
            var agente = await _agenteAppService.GetByMatriculaAsync(matricula);

            if (agente == null)
            {
                return NotFound();
            }

            return Ok(agente);
        }

        [HttpGet("unidad/{unidadId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AgenteDto>>> GetAgentesByUnidad(int unidadId)
        {
            var agentes = await _agenteAppService.GetByUnidadAsync(unidadId);
            return Ok(agentes);
        }

        [HttpGet("empleado/{empleadoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AgenteDto>> GetAgenteByEmpleadoId(int empleadoId)
        {
            var agente = await _agenteAppService.GetByEmpleadoIdAsync(empleadoId);

            if (agente == null)
            {
                return NotFound();
            }

            return Ok(agente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<AgenteDto>> PostAgente([FromBody] AgenteDto agenteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agente = await _agenteAppService.AddAsync(agenteDto);
            return CreatedAtAction(nameof(GetAgente), new { id = agente.AgenteId }, agente);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PutAgente(int id, [FromBody] AgenteDto agenteDto)
        {
            if (id != agenteDto.AgenteId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _agenteAppService.UpdateAsync(agenteDto);
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
        public async Task<IActionResult> DeleteAgente(int id)
        {
            try
            {
                await _agenteAppService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}