using Business.Location.Implementation;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Interface
{
    [Route("api/department")]
    public class DepartmetController: ControllerBase
    {
        private readonly IDepartmentBusiness _DepartmentBusiness;
        public DepartmetController(IDepartmentBusiness departmentBusiness)
        {
            _DepartmentBusiness = departmentBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
        {
            var result = await _DepartmentBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(int id)
        {
            var result = await _DepartmentBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("select")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await _DepartmentBusiness.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> Save([FromBody] DepartmentDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _DepartmentBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { Id = result.id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentDto entity)
        {
            if (entity == null || id != entity.id)
            {
                return BadRequest();
            }
            try
            {
                await _DepartmentBusiness.Update(id, entity);
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
            await _DepartmentBusiness.Delete(id);
            return NoContent();
        }
    }
}
