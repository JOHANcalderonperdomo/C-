using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementacion
{
    public interface IUsuarioRolBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioRolDto>> GetAll();
        Task<Usuario_rol> Save(UsuarioRolDto entity);
        Task Update(int id, UsuarioRolDto entity);
        Task<UsuarioRolDto> GetById(int id);

    }
}
