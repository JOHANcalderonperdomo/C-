using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    public interface IVistaController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<VistaDto>> GetAll();
        Task<ActionResult<VistaDto>> Save([FromBody] VistaDto entity);
        Task<VistaDto> GetById(int id);
        Task<ActionResult> Update(int id, [FromBody] VistaDto entity);
    }
}
