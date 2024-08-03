using Business.Implementacion;
using Entity.Dto;
using Data.Implementation;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public class RolBusiness: IRolBusiness
    {
            private readonly IRolData data;
            public RolBusiness(IRolData data)
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

            public async Task<RolDto> GetById(int id)
            {
                Rol rol = await data.GetById(id);
                RolDto rolDto = new RolDto();

                rolDto.Id = rol.Id;
                rolDto.Name = rol.nombre;
                rolDto.Description = rol.descripcion;
                rolDto.State = rol.estado;



                return rolDto;
            }

            public async Task<Rol> Save(RolDto entity)
            {
                Rol rol = new Rol();
                rol = mapearDatos(rol, entity);

                return await data.Save(rol);
            }

            public async Task Update(int id, RolDto entity)
            {
                Rol rol = await data.GetById(id);
                if (rol == null)
                {
                    throw new Exception("Registro no encontrado");
                }
                rol = mapearDatos(rol, entity);

                await data.Update(rol);
            }

            public async Task<IEnumerable<RolDto>> GetAll()
            {
                return await data.GetAll();
            }

            private Rol mapearDatos(Rol rol, RolDto entity)
            {
                rol.Id = entity.Id;
                rol.nombre = entity.Name;
                rol.descripcion = entity.Description;
                rol.estado = entity.State;

                return rol;
            }
    }
}
