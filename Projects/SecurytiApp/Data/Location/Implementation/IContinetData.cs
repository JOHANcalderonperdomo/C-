﻿using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Location.Implementation
{
    public interface IContinetData
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ContinetDto>> GetAll();
        Task<Continet> Save(Continet entity);
        Task<Continet> GetById(int id);
        Task Update(Continet entity);
    }
}