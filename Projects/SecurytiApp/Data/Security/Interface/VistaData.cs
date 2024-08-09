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
                        nombre AS Nombre 
                    FROM 
                        vistas
                    WHERE deleted_at IS NULL 
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Vista> GetById(int id)
        {
            var sql = @"SELECT * FROM vistas WHERE Id = @Id ORDER BY Id ASC";
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
                            nombre,
                            descripcion,
                            ruta,
                            moduloId,
                            created_at,
                            updated_at,
                            deleted_at,
                            estado 
                        FROM 
                            vistas
                        WHERE deleted_at IS NULL AND estado = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<VistaDto>(sql);
        }

    }
}
