using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Location.Implementation
{
    public interface ICountryController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CountryDto>> GetAll();
        Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity);
        Task<CountryDto> GetByID(int id);
        Task<IActionResult> Update(int id, [FromBody] CountryDto entity);
    }
}
