using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Location.Implementation
{
    public interface ICityData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CityDto>> GetAll();
        Task<City> Save(City entity);
        Task<City> GetById(int id);
        Task Update(City entity);
    }
}
