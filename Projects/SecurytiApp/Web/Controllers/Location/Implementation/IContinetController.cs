using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Implementation
{
    public interface IContinetController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ContinetDto>> GetAll();
        Task<ActionResult<ContinetDto>> Save([FromBody] ContinetDto entity);
        Task<ContinetDto> GetByID(int id);
        Task<IActionResult> Update(int id, [FromBody] ContinetDto entity);
    }
}
