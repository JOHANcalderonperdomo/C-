using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Implementation
{
    public interface ICityController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CityDto>> GetAll();
        Task<ActionResult<CityDto>> Save([FromBody] CityDto entity);
        Task<CityDto> GetByID(int id);
        Task<IActionResult> Update(int id, [FromBody] CityDto entity);
    }
}
