using Business.Interface;
using Business.Implementacion;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    [Route("api/vista")]
    public class VistaController : ControllerBase
    {
        private readonly IVistaBusiness _VistaBusiness;
        public VistaController(IVistaBusiness VistaBusiness)
        {
            _VistaBusiness = VistaBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VistaDto>>> GetAll()
        {
            var result = await _VistaBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VistaDto>> GetById(int id)
        {
            var result = await _VistaBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _VistaBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<VistaDto>> Save([FromBody] VistaDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _VistaBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VistaDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _VistaBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _VistaBusiness.Delete(id);
            return NoContent();
        }
    }
}

