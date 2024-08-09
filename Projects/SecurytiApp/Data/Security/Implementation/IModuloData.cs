using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Implementation
{
    public interface IModuloData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<Modulo> Save(Modulo entity);
        Task Update(Modulo entity);
        Task<Modulo> GetById(int id);
    }
}
