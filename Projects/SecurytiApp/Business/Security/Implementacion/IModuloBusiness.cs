using Business.Security.Interface;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.Implementacion
{
    public interface IModuloBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<ModuloDto>> GetAll();
        Task<Modulo> Save(ModuloDto entity);
        Task Update(int id, ModuloDto entity);

        Task<ModuloDto> GetById(int id);

    }
}
