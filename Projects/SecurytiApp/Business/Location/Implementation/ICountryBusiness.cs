using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using Entity.Model.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.DTO.LocationDto;

namespace Business.Location.Implementation
{
    public interface ICountryBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<CountryDto>> GetAll();
        Task<Country> Save(CountryDto entity);
        Task Update(int id, CountryDto entity);

        Task<CountryDto> GetById(int id);
    }
}
