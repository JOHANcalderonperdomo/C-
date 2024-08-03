using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    public interface IRolController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolDto>> GetAll();
        Task<ActionResult<RolDto>> Save([FromBody] RolDto entity);
        Task<RolDto> GetById(int id);
        Task<ActionResult> Update(int id, [FromBody] RolDto entity);
    }
}
