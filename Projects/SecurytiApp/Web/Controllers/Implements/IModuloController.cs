using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    public interface IModuloController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<ActionResult<ModuloDto>> Save([FromBody] ModuloDto entity);
        Task<ModuloDto> GetById(int id);
        Task<ActionResult> Update(int id, [FromBody] ModuloDto entity);
    }
}
