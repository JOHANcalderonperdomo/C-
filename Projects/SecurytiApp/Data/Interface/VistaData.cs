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
    public class VistaData : IVistaData
    {

        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public VistaData(ApplicationDbContext context, IConfiguration configuration)
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
            context.vistas.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        name AS Nombre 
                    FROM 
                        Security.Vista
                    WHERE DeletedAt IS NULL AND Estado = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Vista> GetById(int id)
        {
            var sql = @"SELECT * FROM Security.Vista WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Vista>(sql, new { Id = id });
        }

        public async Task<Vista> Save(Vista entity)
        {
            context.vistas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Vista entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VistaDto>> GetAll()
        {
            var sql = @"SELECT 
                            Id,
                            name,
                            description,
                            route,
                            moduleName,
                            CreatedAt,
                            UpdatedAt,
                            DeletedAt,
                            State 
                        FROM 
                            Security.Vista
                        WHERE DeletedAt IS NULL AND State = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<VistaDto>(sql);
        }

    }
}
