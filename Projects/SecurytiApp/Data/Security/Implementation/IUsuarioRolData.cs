using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Implementation
{
    public interface IUsuarioRolData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioRolDto>> GetAll();
        Task<Usuario_rol> Save(Usuario_rol entity);
        Task Update(Usuario_rol entity);
        Task<Usuario_rol> GetById(int id);
    }
}
