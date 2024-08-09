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
    public class PersonaData : IPersonaData
    {

        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public PersonaData(ApplicationDbContext context, IConfiguration configuration)
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
            context.personas.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        nombre AS Nombre 
                    FROM 
                        personas
                  WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Persona> GetById(int id)
        {
            var sql = @"SELECT * FROM personas WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Persona>(sql, new { Id = id });
        }

        public async Task<IEnumerable<PersonaDto>> GetAll()
        {
            var sql = @"SELECT 
                            Id,
                            nombre,
                            apellido,
                            correo,
                            genero,
                            documento,
                            tipo_de_documento,
                            direccion,
                            numero,
                            birthday,
                            created_at,
                            created_by,
                            updated_by,
                            deleted_by,
                            updated_at,
                            deleted_at,
                            estado 
                        FROM 
                            dbo.personas
                       WHERE deleted_at IS NULL AND estado = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<PersonaDto>(sql);
        }
        public async Task<Persona> Save(Persona entity)
        {
            context.personas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Persona entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
