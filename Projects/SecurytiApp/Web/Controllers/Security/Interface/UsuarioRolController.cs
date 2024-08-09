using Business.Security.Implementacion;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Interface
{
    [Route("api/usuario_rol")]

    public class UsuarioRolController : ControllerBase
    {
        private readonly IUsuarioRolBusiness _UsuarioRolBusiness;
        public UsuarioRolController(IUsuarioRolBusiness UsuarioRolBusiness)
        {
            _UsuarioRolBusiness = UsuarioRolBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRolDto>>> GetAll()
        {
            var result = await _UsuarioRolBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRolDto>> GetById(int id)
        {
            var result = await _UsuarioRolBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _UsuarioRolBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioRolDto>> Save([FromBody] UsuarioRolDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _UsuarioRolBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioRolDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _UsuarioRolBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _UsuarioRolBusiness.Delete(id);
            return NoContent();
        }
    }
}
