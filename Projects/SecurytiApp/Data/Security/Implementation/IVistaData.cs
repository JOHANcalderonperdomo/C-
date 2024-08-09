using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Implementation
{
    public interface IVistaData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<VistaDto>> GetAll();
        Task<Vista> Save(Vista entity);
        Task Update(Vista entity);

        Task<Vista> GetById(int id);

    }
}
