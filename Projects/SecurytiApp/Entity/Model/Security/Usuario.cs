using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Usuario
    {
        public int Id { get; set; } 
        public string nombre_de_usuario { get; set; }
        public string contraseña { get; set; }
        public int persona_id { get; set; }
        public Persona persona { get; set; }

        public DateTime created_at { get; set; }

        public DateTime created_by { get; set; }

        public DateTime updated_at { get; set; }

        public DateTime updated_by { get; set; }

        public DateTime deleted_at { get; set; }
        public DateTime deleted_by { get; set; }

        public Boolean estado { get; set; }
    }
}
