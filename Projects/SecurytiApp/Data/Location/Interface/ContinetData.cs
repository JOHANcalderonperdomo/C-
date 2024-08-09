using Data.Location.Implementation;
using Entity.Model.Context;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using Entity.Model.Entity.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Location.Interface
{
    public class ContinetData: IContinetData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public ContinetData(ApplicationDbContext context, IConfiguration configuration)
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
            context.continet.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        name AS Nombre 
                    FROM 
                        continet
                  WHERE deleted_at IS NULL AND estado = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Continet> GetById(int id)
        {
            var sql = @"SELECT * FROM continet WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Continet>(sql, new { Id = id });
        }

        public async Task<IEnumerable<ContinetDto>> GetAll()
        {
            var sql = @"SELECT 
                            name,
                            code,
                            description,
                            estado 
                        FROM 
                            continet
                       WHERE deleted_at IS NULL AND estado = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<ContinetDto>(sql);
        }
        public async Task<Continet> Save(Continet entity)
        {
            context.continet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Continet entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}

