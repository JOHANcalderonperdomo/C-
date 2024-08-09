using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Location.Implementation
{
    public interface IDepartmentBusiness
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<IEnumerable<DepartmentDto>> GetAll();
        Task<Department> Save(DepartmentDto entity);
        Task Update(int id, DepartmentDto entity);

        Task<DepartmentDto> GetById(int id);
    }
}
