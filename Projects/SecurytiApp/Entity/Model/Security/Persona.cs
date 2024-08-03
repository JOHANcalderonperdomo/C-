using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Persona
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public DateTime fecha_de_nacimiento { get; set; }
        public string genero { get; set; }
        public string direccion { get; set; }
        public string tipo_de_documento { get; set; }
        public string documento { get; set; }
        public string numero { get; set; }
        public DateTime birthday { get; set; }

        public DateTime created_at { get; set; }

        public DateTime created_by { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime updated_by { get; set; }

        public DateTime deleted_at { get; set; }
        public DateTime deleted_by { get; set; }    

        public Boolean estado { get; set; }

    }
}
