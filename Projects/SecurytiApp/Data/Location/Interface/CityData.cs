using Data.Location.Implementation;
using Entity.Model.Context;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Location.Interface
{
    public class CityData: ICityData
    {
        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDbContext context, IConfiguration configuration)
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
            context.city.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        name AS Nombre 
                    FROM 
                        city
                  WHERE deleted_at IS NULL AND estado = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM city WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var sql = @"SELECT 
                            name,
                            code,
                            description,
                            estado 
                        FROM 
                            city
                       WHERE deleted_at IS NULL AND estado = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<CityDto>(sql);
        }
        public async Task<City> Save(City entity)
        {
            context.city.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(City entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
