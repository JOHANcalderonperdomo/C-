using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;

namespace Data.Security.Implementation
{
    public interface IPersonaData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<PersonaDto>> GetAll();
        Task<Persona> Save(Persona entity);
        Task Update(Persona entity);

        Task<Persona> GetById(int id);

    }
}
