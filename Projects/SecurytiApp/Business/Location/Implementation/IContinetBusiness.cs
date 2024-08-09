using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Location.Implementation
{
    public interface IContinetBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ContinetDto>> GetAll();
        Task<Continet> Save(ContinetDto entity);
        Task Update(int id, ContinetDto entity);

        Task<ContinetDto> GetById(int id);
    }
}
