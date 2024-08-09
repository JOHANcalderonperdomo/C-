using Business.Location.Implementation;
using Data.Location.Implementation;
using Entity.Model.DTO.LocationDto;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Location.Interface
{
    public class DepartmentBusiness: IDepartmentBusiness
    {
        private readonly IDepartmentData data;

        public DepartmentBusiness(IDepartmentData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            Department department = await data.GetById(id);
            DepartmentDto departmentDto = new DepartmentDto();

            departmentDto.id = department.id;
            departmentDto.name = department.name;
            departmentDto.code = department.code;
            departmentDto.description = department.description;
            departmentDto.countryId = department.countryId;
            departmentDto.estado = department.estado;


            return departmentDto;
        }

        public async Task<Department> Save(DepartmentDto entity)
        {
            Department department = new Department();
            department = mapearDatos(department, entity);

            return await data.Save(department);
        }

        public async Task Update(int id, DepartmentDto entity)
        {
            Department department = await data.GetById(id);
            if (department == null)
            {
                throw new Exception("Registro no encontrado");
            }
            department = mapearDatos(department, entity);

            await data.Update(department);
        }

        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Department mapearDatos(Department department, DepartmentDto entity)
        {
            department.id = entity.id;
            department.name = entity.name;
            department.code = entity.code;
            department.description = entity.description;
            department.countryId = entity.countryId;
            department.estado = entity.estado;

            return department;
        }
    }
}
