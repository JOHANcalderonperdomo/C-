using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public interface IUsuarioData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<UsuarioDto>> GetAll();
        Task<Usuario> Save(Usuario entity);
        Task Update(Usuario entity);

        Task<Usuario> GetById(int id);

    }
}
