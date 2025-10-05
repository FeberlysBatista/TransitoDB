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
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaAppService _personaAppService;

        public PersonaController(IPersonaAppService personaAppService)
        {
            _personaAppService = personaAppService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetPersonas()
        {
            var personas = await _personaAppService.GetAllAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDto>> GetPersona(int id)
        {
            var persona = await _personaAppService.GetByIdAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        [HttpGet("cedula/{cedula}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDto>> GetPersonaByCedula(string cedula)
        {
            var persona = await _personaAppService.GetByCedulaAsync(cedula);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<ActionResult<PersonaDto>> PostPersona([FromBody] PersonaDto personaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persona = await _personaAppService.AddAsync(personaDto);
            return CreatedAtAction(nameof(GetPersona), new { id = persona.PersonaId }, persona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Administrador,Supervisor")]
        public async Task<IActionResult> PutPersona(int id, [FromBody] PersonaDto personaDto)
        {
            if (id != personaDto.PersonaId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _personaAppService.UpdateAsync(personaDto);
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
        public async Task<IActionResult> DeletePersona(int id)
        {
            try
            {
                await _personaAppService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}