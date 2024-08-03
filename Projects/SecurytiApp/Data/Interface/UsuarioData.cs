using Entity.Dto;
using Data.Implementation;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
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
                        UserName AS Nombre 
                    FROM 
                        Security.Usuario
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Usuario> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Usuario WHERE Id = @Id ORDER BY Id ASC";
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

        public  async Task<IEnumerable<UsuarioDto>> GetAll()
        {
            var sql = @"SELECT 
                            Id,
                            UserName,
                            password,
                            CreatedAt,
                            UpdatedAt,
                            DeletedAt,
                            State 
                        FROM 
                            Security.Usuario
                        WHERE DeletedAt IS NULL AND State = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<UsuarioDto>(sql);
        }

    }
}
