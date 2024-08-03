using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
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
