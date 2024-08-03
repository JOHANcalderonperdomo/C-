using Business.Implementacion;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    [Route("api/rol_vista")]
    public class RolVistaController : ControllerBase
    {
        private readonly IRolVistaBusiness _RolVistaBusiness;
        public RolVistaController(IRolVistaBusiness RolVistaBusiness)
        {
            _RolVistaBusiness = RolVistaBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolVistaDto>>> GetAll()
        {
            var result = await _RolVistaBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolVistaDto>> GetById(int id)
        {
            var result = await _RolVistaBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _RolVistaBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RolVistaDto>> Save([FromBody] RolVistaDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _RolVistaBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolVistaDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _RolVistaBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RolVistaBusiness.Delete(id);
            return NoContent();
        }
    }
}
