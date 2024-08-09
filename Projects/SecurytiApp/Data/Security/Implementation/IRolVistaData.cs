﻿using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Security.Implementation
{
    public interface IRolVistaData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<RolVistaDto>> GetAll();
        Task<Rol_Vista> Save(Rol_Vista entity);
        Task Update(Rol_Vista entity);
        Task<Rol_Vista> GetById(int id);
    }
}
