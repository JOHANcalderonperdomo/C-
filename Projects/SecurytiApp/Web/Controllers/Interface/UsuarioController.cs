using Business.Interface;
using Business.Implementacion;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    [Route("api/usuario")]
    public class UsuarioController: ControllerBase
    {
        private readonly IUsuarioBusiness _UsuarioBusiness;
        public UsuarioController(IUsuarioBusiness UsuarioBusiness)
        {
            _UsuarioBusiness = UsuarioBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetAll()
        {
            var result = await _UsuarioBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var result = await _UsuarioBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _UsuarioBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Save([FromBody] UsuarioDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _UsuarioBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _UsuarioBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _UsuarioBusiness.Delete(id);
            return NoContent();
        }
    }
}

