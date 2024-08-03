using Business.Interface;
using Business.Implementacion;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    [Route("api/modulo")]
    public class ModuloController: ControllerBase
    {
        private readonly IModuloBusiness _ModuloBusiness;
        public ModuloController(IModuloBusiness ModuloBusiness)
        {
            _ModuloBusiness = ModuloBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuloDto>>> GetAll()
        {
            var result = await _ModuloBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModuloDto>> GetById(int id)
        {
            var result = await _ModuloBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _ModuloBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ModuloDto>> Save([FromBody] ModuloDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _ModuloBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ModuloDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _ModuloBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ModuloBusiness.Delete(id);
            return NoContent();
        }
    }
}

