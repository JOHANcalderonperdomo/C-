 using Entity.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers.Implements

{
    public interface IPersonaController
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<PersonaDto>> GetAll();
        Task<ActionResult<PersonaDto>> Save([FromBody] PersonaDto entity);
        Task<PersonaDto> GetByID(int id);
        Task<IActionResult> Update(int id, [FromBody] PersonaDto entity);



    }
}
