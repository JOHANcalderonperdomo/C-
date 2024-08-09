using Data.Security.Implementation;
using Entity.Model.Context;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Interface
{
    public class UsuarioRolData : IUsuarioRolData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public UsuarioRolData(ApplicationDbContext context, IConfiguration configuration)
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
            context.usuario_rol.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        id AS Nombre 
                    FROM 
                        Usuario_rol
                    WHERE deleted_at IS NULL AND state = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Usuario_rol> GetById(int id)
        {
            var sql = @"SELECT * FROM Usuario_rol WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Usuario_rol>(sql, new { Id = id });
        }

        public async Task<IEnumerable<UsuarioRolDto>> GetAll()
        {
            var sql = @"SELECT 
                            Id,
                            rol_id,
                            usuario_id
                        FROM 
                            Usuario_rol
                        WHERE deleted_at IS NULL AND state = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<UsuarioRolDto>(sql);
        }
        public async Task<Usuario_rol> Save(Usuario_rol entity)
        {
            context.usuario_rol.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Usuario_rol entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
