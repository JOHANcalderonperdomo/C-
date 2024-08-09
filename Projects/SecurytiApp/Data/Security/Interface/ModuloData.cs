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
    public class ModuloData : IModuloData
    {


        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ModuloData(ApplicationDbContext context, IConfiguration configuration)
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
            context.modulo.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        nombre AS Nombre 
                    FROM 
                        modulo
                        WHERE deleted_at IS NULL 
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM modulo WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Modulo>(sql, new { Id = id });
        }

        public async Task<Modulo> Save(Modulo entity)
        {
            context.modulo.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            var sql = @"SELECT 
                            Id,
                            nombre,
                            descripcion
                        FROM 
                            modulo
                        WHERE deleted_at IS NULL AND state = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<ModuloDto>(sql);
        }
    }
}
