using Business.Implementacion;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Implements;

namespace Web.Controllers.Interface
{
    [Route("api/persona")]
    public class PersonaController : ControllerBase
    {
            private readonly IPersonaBusiness _PersonaBusiness;
            public PersonaController(IPersonaBusiness PersonaBusiness)
            {
                _PersonaBusiness = PersonaBusiness;
            }
            [HttpGet]
            public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAll()
            {
                var result = await _PersonaBusiness.GetAll();
                return Ok(result);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<PersonaDto>> GetById(int id)
            {
                var result = await _PersonaBusiness.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }

            [HttpGet("select")]
            public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
            {
                var result = await _PersonaBusiness.GetAllSelect();
                return Ok(result);
            }

            [HttpPost]
            public async Task<ActionResult<PersonaDto>> Save([FromBody] PersonaDto entity)
            {
                if (entity == null)
                {
                    return BadRequest("Entity is null");
                }
                var result = await _PersonaBusiness.Save(entity);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, [FromBody] PersonaDto entity)
            {
                if (entity == null || id != entity.Id)
                {
                    return BadRequest();
                }
                await _PersonaBusiness.Update(id, entity);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _PersonaBusiness.Delete(id);
                return NoContent();
            }
    }
}
