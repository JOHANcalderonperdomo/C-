using Business.Security.Implementacion;
using Data.Security.Implementation;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Interface
{
    public class UsuarioRolBusiness : IUsuarioRolBusiness
    {
        private readonly IUsuarioRolData data;

        public UsuarioRolBusiness(IUsuarioRolData data)
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

        public async Task<UsuarioRolDto> GetById(int id)
        {
            Usuario_rol usuario_rol = await data.GetById(id);
            UsuarioRolDto UsuarioRolDto = new UsuarioRolDto();

            UsuarioRolDto.Id = usuario_rol.Id;
            UsuarioRolDto.UsuarioId = usuario_rol.usuario_id;
            UsuarioRolDto.RolId = usuario_rol.rol_id;


            return UsuarioRolDto;
        }

        public async Task<Usuario_rol> Save(UsuarioRolDto entity)
        {
            Usuario_rol usuario_Rol = new Usuario_rol();
            usuario_Rol = mapearDatos(usuario_Rol, entity);

            return await data.Save(usuario_Rol);
        }

        public async Task Update(int id, UsuarioRolDto entity)
        {
            Usuario_rol usuario_Rol = await data.GetById(id);
            if (usuario_Rol == null)
            {
                throw new Exception("Registro no encontrado");
            }
            usuario_Rol = mapearDatos(usuario_Rol, entity);

            await data.Update(usuario_Rol);
        }

        public async Task<IEnumerable<UsuarioRolDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Usuario_rol mapearDatos(Usuario_rol usuario_Rol, UsuarioRolDto entity)
        {
            usuario_Rol.Id = entity.Id;
            usuario_Rol.usuario_id = entity.UsuarioId;
            usuario_Rol.rol_id = entity.RolId;

            return usuario_Rol;
        }
    }
}
