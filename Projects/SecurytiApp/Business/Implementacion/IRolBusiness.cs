using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementacion
{
    public interface IRolBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolDto>> GetAll();
        Task<Rol> Save(RolDto entity);
        Task Update(int id, RolDto entity);
        Task<RolDto> GetById(int id);
    }
}
