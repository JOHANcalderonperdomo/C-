using Entity.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using Data.Security.Implementation;

namespace Data.Security.Interface
{
    public class UsuarioData : IUsuarioData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UsuarioData(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.usuario.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        nombre_de_usuario AS Nombre 
                    FROM 
                        usuario
                    WHERE DeletedAt IS NULL 
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Usuario> GetById(int id)
        {
            var sql = @"SELECT * FROM usuario WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }


        public async Task<Usuario> Save(Usuario entity)
        {
            context.usuario.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Usuario entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            var sql = @"SELECT 
                            Id,
                            nombre_de_usuario,
                            contraseña,
                            personaId,
                            created_at,
                            updated_at,
                            deleted_at,
                            estado 
                        FROM 
                            usuario
                        WHERE deleted_at IS NULL AND estado = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<UsuarioDto>(sql);
        }

        public async Task<UsuarioDto> GetByLogin(LoginDto loginDto)
        {
            var usuario = await context.usuario.FirstOrDefaultAsync(u => u.nombre_de_usuario == loginDto.nombre && u.contraseña == loginDto.contraseña);
            if (usuario == null)
            {
                return null;
            }

            var usuarioDto = new UsuarioDto
            {
                Id = usuario.Id,
                nombre_de_usuario = usuario.nombre_de_usuario,
                contraseña = usuario.contraseña,
                personaId = usuario.personaId

            };
            return usuarioDto;
        }

        public async Task<IEnumerable<RolDto>> GetUserRolesAsync(int userId)
        {
            return await context.usuario_rol
                .Where(ur => ur.usuario_id == userId)
                .Select(ur => new RolDto { Id = ur.rol.Id, nombre = ur.rol.nombre })
                .ToListAsync();
        }

        public async Task<IEnumerable<VistaDto>> GetRoleViewsAsync(int roleId)
        {
            return await context.rol_vista
                                .Where(rv => rv.rol.Id == roleId)
                                .Select(rv => new VistaDto { Id = rv.rol.Id, nombre = rv.rol.nombre })
                                .ToListAsync();
        }
    }
}
