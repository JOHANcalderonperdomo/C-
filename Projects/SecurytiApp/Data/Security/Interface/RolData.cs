﻿using Entity.Model.Context;
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
    public class RolData : IRolData
    {


        private readonly ApplicationDbContext context;
        protected readonly IConfiguration configuration;

        public RolData(ApplicationDbContext context, IConfiguration configuration)
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
            context.rol.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        nombre AS Nombre 
                    FROM 
                        rol
                    WHERE deleted_at IS NULL 
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Rol> GetById(int id)
        {
            var sql = @"SELECT * FROM rol WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Rol>(sql, new { Id = id });
        }

        public async Task<Rol> Save(Rol entity)
        {
            context.rol.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Rol entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RolDto>> GetAll()
        {
            var sql = @"SELECT 
                            Id,
                            nombre,
                            descripcion,
                            updated_at,
                            deleted_at,
                            estado 
                        FROM 
                            Rol
                        WHERE deleted_at IS NULL AND estado = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<RolDto>(sql);
        }
    }
}
