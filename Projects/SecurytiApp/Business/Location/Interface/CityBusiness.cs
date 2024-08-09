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
    public class CityBusiness: ICityBusiness
    {
        private readonly ICityData data;

        public CityBusiness(ICityData data)
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

        public async Task<CityDto> GetById(int id)
        {
            City city = await data.GetById(id);
            CityDto cityDto = new CityDto();

            cityDto.id = city.id;
            cityDto.name = city.name;
            cityDto.code = city.code;
            cityDto.description = city.description;
            cityDto.departmentId = city.departmentId;
            cityDto.estado = city.estado;


            return cityDto;
        }

        public async Task<City> Save(CityDto entity)
        {
            City city = new City();
            city = mapearDatos(city, entity);

            return await data.Save(city);
        }

        public async Task Update(int id, CityDto entity)
        {
            City city = await data.GetById(id);
            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }
            city = mapearDatos(city, entity);

            await data.Update(city);
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            return await data.GetAll();
        }

        private City mapearDatos(City city, CityDto entity)
        {
            city.id = entity.id;
            city.name = entity.name;
            city.code = entity.code;
            city.description = entity.description;
            city.departmentId = entity.departmentId;
            city.estado = entity.estado;

            return city;
        }
    }
}
