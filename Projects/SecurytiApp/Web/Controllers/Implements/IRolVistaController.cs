using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    public interface IRolVistaController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolVistaDto>> GetAll();
        Task<ActionResult<RolVistaDto>> Save([FromBody] RolVistaDto entity);
        Task<RolVistaDto> GetByID(int id);
        Task<IActionResult> Update(int id, [FromBody] RolVistaDto entity);
    }
}
