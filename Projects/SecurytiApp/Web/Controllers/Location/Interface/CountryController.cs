using Business.Location.Implementation;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Interface
{
    [Route("api/country")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryBusiness _CountryBusiness;
        public CountryController(ICountryBusiness countryBusiness)
        {
            _CountryBusiness = countryBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
            var result = await _CountryBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var result = await _CountryBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _CountryBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _CountryBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { Id = result.id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CountryDto entity)
        {
            if (entity == null || id != entity.id)
            {
                return BadRequest();
            }
            try
            {
                await _CountryBusiness.Update(id, entity);
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
            await _CountryBusiness.Delete(id);
            return NoContent();
        }
    }
}
