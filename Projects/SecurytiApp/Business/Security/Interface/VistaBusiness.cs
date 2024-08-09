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
    public class VistaBusiness : IVistaBusiness
    {
        private readonly IVistaData data;
        public VistaBusiness(IVistaData data)
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

        public async Task<VistaDto> GetById(int id)
        {
            Vista vista = await data.GetById(id);
            VistaDto vistaDto = new VistaDto();

            vistaDto.Id = vista.Id;
            vistaDto.nombre = vista.nombre;
            vistaDto.descripcion = vista.descripcion;
            vistaDto.ruta = vista.ruta;
            vistaDto.moduloId = vista.moduloId;



            return vistaDto;
        }

        public async Task<Vista> Save(VistaDto entity)
        {
            Vista vista = new Vista();
            vista = mapearDatos(vista, entity);

            return await data.Save(vista);
        }

        public async Task Update(int id, VistaDto entity)
        {
            Vista vista = await data.GetById(id);
            if (vista == null)
            {
                throw new Exception("Registro no encontrado");
            }
            vista = mapearDatos(vista, entity);

            await data.Update(vista);
        }

        public async Task<IEnumerable<VistaDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Vista mapearDatos(Vista vista, VistaDto entity)
        {
            vista.Id = entity.Id;
            vista.nombre = entity.nombre;
            vista.descripcion = entity.descripcion;
            vista.ruta = entity.ruta;
            vista.moduloId = entity.moduloId;

            return vista;
        }

    }
}
