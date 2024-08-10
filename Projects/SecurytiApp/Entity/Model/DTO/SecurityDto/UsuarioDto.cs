using Entity.Model.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.DTO.SecurityDto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string nombre_de_usuario { get; set; }
        public string contrasena { get; set; }
        public int personaId { get; set; }
        public Boolean estado {  get; set; }


    }

}
