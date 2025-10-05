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
    public class ConductorController : ControllerBase
    {
        private readonly IConductorAppService _conductorAppService;

        public ConductorController(IConductorAppService conductorAppService)
        {
            _conductorAppService = conductorAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ConductorDto>>> GetConductores()
        {
            var conductores = await _conductorAppService.GetAllAsync();
            return Ok(conductores);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConductorDto>> GetConductor(int id)
        {
            var conductor = await _conductorAppService.GetByIdAsync(id);

            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(conductor);
        }

        [HttpGet("licencia/{licenciaNro}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConductorDto>> GetConductorByLicencia(string licenciaNro)
        {
            var conductor = await _conductorAppService.GetByLicenciaAsync(licenciaNro);

            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(conductor);
        }

        [HttpGet("cedula/{cedula}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConductorDto>> GetConductorByCedula(string cedula)
        {
            var conductor = await _conductorAppService.GetByCedulaAsync(cedula);

            if (conductor == null)
            {
                return NotFound();
            }

            return Ok(conductor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador,Supervisor,Oficial")]
        public async Task<ActionResult<ConductorDto>> PostConductor([FromBody] ConductorDto conductorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var conductor = await _conductorAppService.AddAsync(conductorDto);
            return CreatedAtAction(nameof(GetConductor), new { id = conductor.ConductorId }, conductor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrador,Supervisor,Oficial")]
        public async Task<IActionResult> PutConductor(int id, [FromBody] ConductorDto conductorDto)
        {
            // 1) ID de ruta debe coincidir con el del body
            if (id != conductorDto.ConductorId)
                return BadRequest("El id de la ruta no coincide con el del cuerpo.");

            // 2) Modelo válido
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // 3) Verificar que exista antes de actualizar
            var existente = await _conductorAppService.GetByIdAsync(id);
            if (existente == null)
                return NotFound();

            // 4) Actualizar
            await _conductorAppService.UpdateAsync(conductorDto);

            // 5) Responder
            return NoContent();
        }

    }
}