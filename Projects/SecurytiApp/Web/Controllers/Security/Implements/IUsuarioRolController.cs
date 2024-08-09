using Entity.Model.DTO.SecurityDto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Security.Implements
{
    public interface IUsuarioRolController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioRolDto>> GetAll();
        Task<ActionResult<UsuarioRolDto>> Save([FromBody] UsuarioRolDto entity);
        Task<UsuarioRolDto> GetByID(int id);
        Task<IActionResult> Update(int id, [FromBody] UsuarioRolDto entity);
    }
}
