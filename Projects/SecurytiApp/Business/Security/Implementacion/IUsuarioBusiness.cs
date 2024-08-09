using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementacion
{
    public interface IUsuarioBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioDto>> GetAll();
        Task<Usuario> Save(UsuarioDto entity);
        Task Update(int id, UsuarioDto entity);
        Task<UsuarioDto> GetById(int id);
        Task<menuDto> LoginAsync(LoginDto loginDto);
    }
}
