using Business.Location.Implementation;
using Data.Location.Implementation;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Location.Interface
{
    public class CountryBusiness: ICountryBusiness
    {
        private readonly ICountryData data;

        public CountryBusiness(ICountryData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<CountryDto> GetById(int id)
        {
            Country country = await data.GetById(id);
            CountryDto countryDto = new CountryDto();

            countryDto.id = country.id;
            countryDto.name = country.name;
            countryDto.code = country.code;
            countryDto.description = country.description;
            countryDto.Continet_id = country.Continet_id;
            countryDto.estado = country.estado;


            return countryDto;
        }

        public async Task<Country> Save(CountryDto entity)
        {
            Country country = new Country();
            country = mapearDatos(country, entity);

            return await data.Save(country);
        }

        public async Task Update(int id, CountryDto entity)
        {
            Country country = await data.GetById(id);
            if (country == null)
            {
                throw new Exception("Registro no encontrado");
            }
            country = mapearDatos(country, entity);

            await data.Update(country);
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Country mapearDatos(Country country, CountryDto entity)
        {
            country.id = entity.id;
            country.name = entity.name;
            country.code = entity.code;
            country.description = entity.description;
            country.Continet_id = entity.Continet_id;
            country.estado = entity.estado;

            return country;
        }
    }
}
