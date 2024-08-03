using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementacion
{
    public interface IVistaBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<VistaDto>> GetAll();
        Task <Vista> Save(VistaDto entity);
        Task Update(int id, VistaDto entity);
        Task<VistaDto> GetById(int id);
     
    }
}
