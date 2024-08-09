using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using Data.Security.Implementation;
using Business.Security.Implementacion;

namespace Business.Security.Interface
{
    public class ModuloBusiness : IModuloBusiness
    {
        private readonly IModuloData data;
        public ModuloBusiness(IModuloData data)
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

        public async Task<ModuloDto> GetById(int id)
        {
            Modulo modulo = await data.GetById(id);
            ModuloDto moduloDto = new ModuloDto();

            moduloDto.Id = modulo.Id;
            moduloDto.nombre = modulo.nombre;
            moduloDto.descripcion = modulo.descripcion;




            return moduloDto;
        }

        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();
            modulo = mapearDatos(modulo, entity);

            return await data.Save(modulo);
        }

        public async Task Update(int id, ModuloDto entity)
        {
            Modulo modulo = await data.GetById(id);
            if (modulo == null)
            {
                throw new Exception("Registro no encontrado");
            }
            modulo = mapearDatos(modulo, entity);

            await data.Update(modulo);
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Modulo mapearDatos(Modulo modulo, ModuloDto entity)
        {
            modulo.Id = entity.Id;
            modulo.nombre = entity.nombre;
            modulo.descripcion = entity.nombre;

            return modulo;
        }
    }
}
