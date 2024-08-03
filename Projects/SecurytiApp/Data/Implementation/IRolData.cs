using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public interface IRolData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolDto>> GetAll();
        Task<Rol> Save(Rol entity);
        Task Update(Rol entity);
        Task<Rol> GetById(int id);
    }
}
