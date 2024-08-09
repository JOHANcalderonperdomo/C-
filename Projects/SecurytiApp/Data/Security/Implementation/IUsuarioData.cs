using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Implementation
{
    public interface IUsuarioData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioDto>> GetAll();
        Task<Usuario> Save(Usuario entity);
        Task Update(Usuario entity);

        Task<Usuario> GetById(int id);

        Task<UsuarioDto> GetByLogin(LoginDto loginDto);
        Task<IEnumerable<RolDto>> GetUserRolesAsync(int userId);
        Task<IEnumerable<VistaDto>> GetRoleViewsAsync(int roleId);


    }
}
