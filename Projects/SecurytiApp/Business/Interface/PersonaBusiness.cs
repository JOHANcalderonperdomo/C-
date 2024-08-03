using Business.Implementacion;
using Data.Implementation;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
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
            personaDto.FirstName = persona.nombre;
            personaDto.LastName = persona.apellido;
            personaDto.Email = persona.correo;
            personaDto.Document = persona.documento;
            personaDto.TypeDocument = persona.tipo_de_documento;
            personaDto.Direction = persona.direccion;
            personaDto.Phone = persona.numero;
            personaDto.State = persona.estado;


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
            persona.nombre = entity.FirstName;
            persona.apellido = entity.LastName;
            persona.correo = entity.Email;
            persona.documento = entity.Document;
            persona.tipo_de_documento = entity.TypeDocument;
            persona.direccion = entity.Direction;
            persona.numero = entity.Phone;

            return persona;
        }


    }
}
