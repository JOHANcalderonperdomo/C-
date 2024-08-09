using Business.Security.Implementacion;
using Data.Security.Implementation;
using Entity.Model.DTO.SecurityDto;
using Entity.Model.Entity.Security;
using static Dapper.SqlMapper;

namespace Business.Security.Interface
{
    public class PersonaBusiness : IPersonaBusiness
    {
        private readonly IPersonaData data;

        public PersonaBusiness(IPersonaData data)
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

        public async Task<PersonaDto> GetById(int id)
        {
            Persona persona = await data.GetById(id);
            PersonaDto personaDto = new PersonaDto();

            personaDto.Id = persona.Id;
            personaDto.nombre = persona.nombre;
            personaDto.apellido = persona.apellido;
            personaDto.correo = persona.correo;
            personaDto.genero = persona.genero;
            personaDto.fecha_de_nacimiento = persona.fecha_de_nacimiento;
            personaDto.documento = persona.documento;
            personaDto.tipo_de_documento = persona.tipo_de_documento;
            personaDto.direccion = persona.direccion;
            personaDto.numero = persona.numero;
            personaDto.birthday = persona.birthday;
            personaDto.created_at = persona.created_at;
            personaDto.created_by = persona.created_by;
            personaDto.updated_at = persona.updated_at;
            personaDto.updated_by = persona.updated_by;
            personaDto.deleted_at = persona.deleted_at;
            personaDto.deleted_by = persona.deleted_by;
            personaDto.estado = persona.estado;


            return personaDto;
        }

        public async Task<Persona> Save(PersonaDto entity)
        {
            Persona persona = new Persona();
            persona = mapearDatos(persona, entity);

            return await data.Save(persona);
        }

        public async Task Update(int id, PersonaDto entity)
        {
            Persona persona = await data.GetById(id);
            if (persona == null)
            {
                throw new Exception("Registro no encontrado");
            }
            persona = mapearDatos(persona, entity);

            await data.Update(persona);
        }

        public async Task<IEnumerable<PersonaDto>> GetAll()
        {
            return await data.GetAll();
        }

        private Persona mapearDatos(Persona persona, PersonaDto entity)
        {
            persona.Id = entity.Id;
            persona.nombre = entity.nombre;
            persona.apellido = entity.apellido;
            persona.correo = entity.correo;
            persona.fecha_de_nacimiento = entity.fecha_de_nacimiento;
            persona.genero = entity.genero;
            persona.documento = entity.documento;
            persona.tipo_de_documento = entity.tipo_de_documento;
            persona.direccion = entity.direccion;
            persona.numero = entity.numero;
            persona.birthday = entity.birthday;
            persona.created_at = entity.created_at;
            persona.created_by = entity.created_by;
            persona.updated_at = entity.updated_at;
            persona.updated_by = entity.updated_by;
            persona.deleted_at = entity.deleted_at;
            persona.deleted_by = entity.deleted_by;
            persona.estado = entity.estado;

            return persona;
        }


    }
}
