using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using Data.Security.Implementation;
using Business.Security.Implementacion;

namespace Business.Security.Interface
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioData data;

        public UsuarioBusiness(IUsuarioData data)
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

        public async Task<UsuarioDto> GetById(int id)
        {
            Usuario usuario = await data.GetById(id);
            UsuarioDto usuarioDto = new UsuarioDto();

            usuarioDto.Id = usuario.Id;
            usuarioDto.nombre_de_usuario = usuario.nombre_de_usuario;
            usuarioDto.contraseña = usuario.contraseña;
            usuarioDto.personaId = usuario.personaId;



            return usuarioDto;
        }

        public async Task<Usuario> Save(UsuarioDto entity)
        {
            Usuario usuario = new Usuario();
            usuario = mapearDatos(usuario, entity);

            return await data.Save(usuario);
        }

        public async Task Update(int id, UsuarioDto entity)
        {
            Usuario usuario = await data.GetById(id);
            if (usuario == null)
            {
                throw new Exception("Registro no encontrado");
            }
            usuario = mapearDatos(usuario, entity);

            await data.Update(usuario);
        }

        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Usuario mapearDatos(Usuario usuario, UsuarioDto entity)
        {
            usuario.Id = entity.Id;
            usuario.nombre_de_usuario = entity.nombre_de_usuario;
            usuario.contraseña = entity.contraseña;
            usuario.personaId = entity.personaId;


            return usuario;
        }

        public async Task<menuDto> LoginAsync(LoginDto loginDto)
        {
            var user = await data.GetByLogin(loginDto);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            var roles = await data.GetUserRolesAsync(user.Id);
            var rolvista = new List<VistaDto>();
            foreach (var role in roles)
            {
                var vistas = await data.GetRoleViewsAsync(role.Id);
                rolvista.AddRange(vistas);
            }

            return new menuDto
            {
                User = new UsuarioDto
                {
                    Id = user.Id,
                    nombre_de_usuario = user.nombre_de_usuario,
                    contraseña = user.contraseña,
                    personaId = user.personaId
                },
                Roles = roles.ToList(),
                Views = rolvista.Distinct().ToList()
            };
        }
    }
}

