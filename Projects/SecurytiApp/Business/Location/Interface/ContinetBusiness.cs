using Business.Location.Implementation;
using Data.Location.Implementation;
using Data.Security.Implementation;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Location.Interface
{
    public class ContinetBusiness: IContinetBusiness
    {
        private readonly IContinetData data;

        public ContinetBusiness(IContinetData data)
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

        public async Task<ContinetDto> GetById(int id)
        {
            Continet continet = await data.GetById(id);
            ContinetDto continetDto = new ContinetDto();

            continetDto.Id = continet.id;
            continetDto.name = continet.name;
            continetDto.code = continet.code;
            continetDto.description = continet.description;
            continetDto.estado = continet.estado;


            return continetDto;
        }

        public async Task<Continet> Save(ContinetDto entity)
        {
            Continet continet = new Continet();
            continet = mapearDatos(continet, entity);

            return await data.Save(continet);
        }

        public async Task Update(int id, ContinetDto entity)
        {
            Continet continet = await data.GetById(id);
            if (continet == null)
            {
                throw new Exception("Registro no encontrado");
            }
            continet = mapearDatos(continet, entity);

            await data.Update(continet);
        }

        public async Task<IEnumerable<ContinetDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Continet mapearDatos(Continet continet, ContinetDto entity)
        {
            continet.id = entity.Id;
            continet.name = entity.name;
            continet.code = entity.code;
            continet.description = entity.description;
            continet.estado = entity.estado;

            return continet;
        }
    }
}
