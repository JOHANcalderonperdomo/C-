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
    public interface ICountryData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CountryDto>> GetAll();
        Task<Country> Save(Country entity);
        Task<Country> GetById(int id);
        Task Update(Country entity);
    }
}
