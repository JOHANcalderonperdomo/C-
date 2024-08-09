using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Location.Implementation
{
    public interface ICityBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CityDto>> GetAll();
        Task<City> Save(CityDto entity);
        Task Update(int id, CityDto entity);

        Task<CityDto> GetById(int id);
    }
}
