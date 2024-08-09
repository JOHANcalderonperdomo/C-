using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;

namespace Business.Security.Implementacion
{
    public interface IPersonaBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<PersonaDto>> GetAll();
        Task<Persona> Save(PersonaDto entity);
        Task Update(int id, PersonaDto entity);

        Task<PersonaDto> GetById(int id);

    }
}
