using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementacion
{
    public interface IRolVistaBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolVistaDto>> GetAll();
        Task<Rol_Vista> Save(RolVistaDto entity);
        Task Update(int id, RolVistaDto entity);
        Task<RolVistaDto> GetById(int id);

    }
}
