using Business.Location.Implementation;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Interface
{
    [Route("api/city")]
    public class CityController: ControllerBase
    {
        private readonly ICityBusiness _CityBusiness;
        public CityController(ICityBusiness cityBusiness)
        {
            _CityBusiness = cityBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAll()
        {
            var result = await _CityBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetById(int id)
        {
            var result = await _CityBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _CityBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> Save([FromBody] CityDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _CityBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { Id = result.id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CityDto entity)
        {
            if (entity == null || id != entity.id)
            {
                return BadRequest();
            }
            try
            {
                await _CityBusiness.Update(id, entity);
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
            await _CityBusiness.Delete(id);
            return NoContent();
        }
    }
}
