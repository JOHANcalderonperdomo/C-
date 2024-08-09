using Business.Location.Implementation;
using Business.Location.Interface;
using Business.Security.Implementacion;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Interface
{
    [Route("api/continet")]
    public class ContinetController: ControllerBase
    {
        private readonly IContinetBusiness _ContinetBusiness;
        public ContinetController(IContinetBusiness continetBusiness)
        {
            _ContinetBusiness = continetBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContinetDto>>> GetAll()
        {
            var result = await _ContinetBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContinetDto>> GetById(int id)
        {
            var result = await _ContinetBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _ContinetBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContinetDto>> Save([FromBody] ContinetDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _ContinetBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { Id = result.id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContinetDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            try
            {
                await _ContinetBusiness.Update(id, entity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ContinetBusiness.Delete(id);
            return NoContent();
        }
    }
}
