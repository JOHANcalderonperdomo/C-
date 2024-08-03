using Business.Implementacion;
using Data.Implementation;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public class RolVistaBusiness : IRolVistaBusiness
    {
        private readonly IRolVistaData data;

        public RolVistaBusiness(IRolVistaData data)
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

        public async Task<RolVistaDto> GetById(int id)
        {
            Rol_Vista rol_vista = await data.GetById(id);
            RolVistaDto rolvistaDto = new RolVistaDto();

            rolvistaDto.Id = rol_vista.Id;
            rolvistaDto.RolId = rol_vista.rol_id;
            rolvistaDto.VistaId = rol_vista.vista_id;

            return rolvistaDto;
        }

        public async Task<Rol_Vista> Save(RolVistaDto entity)
        {
            Rol_Vista rol_vista = new Rol_Vista();
            rol_vista = mapearDatos(rol_vista, entity);

            return await data.Save(rol_vista);
        }

        public async Task Update(int id, RolVistaDto entity)
        {
            Rol_Vista rol_vista = await data.GetById(id);
            if (rol_vista == null)
            {
                throw new Exception("Registro no encontrado");
            }
            rol_vista = mapearDatos(rol_vista, entity);

            await data.Update(rol_vista);
        }

        public async Task<IEnumerable<RolVistaDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Rol_Vista mapearDatos(Rol_Vista rol_vista, RolVistaDto entity)
        {
            rol_vista.Id = entity.Id;
            rol_vista.rol_id = entity.RolId;
            rol_vista.vista_id = entity.VistaId;

            return rol_vista;
        }
    }
}
