using Business.Interface;
using Business.Implementacion;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    [Route("api/rol")]
    public class RolController: ControllerBase
    {
        private readonly IRolBusiness _RolBusiness;
        public RolController(IRolBusiness RolBusiness)
        {
            _RolBusiness = RolBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolDto>>> GetAll()
        {
            var result = await _RolBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDto>> GetById(int id)
        {
            var result = await _RolBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _RolBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RolDto>> Save([FromBody] RolDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _RolBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _RolBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RolBusiness.Delete(id);
            return NoContent();
        }
    }
}
