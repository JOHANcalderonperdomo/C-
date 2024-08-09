using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Implementation
{
    public interface IDepartmentController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task<ActionResult<DepartmentDto>> Save([FromBody] DepartmentDto entity);
        Task<DepartmentDto> GetByID(int id);
        Task<IActionResult> Update(int id, [FromBody] DepartmentDto entity);
    }
}
