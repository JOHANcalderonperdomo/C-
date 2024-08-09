using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.DTO.SecurityDto
{
    public class menuDto
    {
        public UsuarioDto User { get; set; }
        public List<RolDto> Roles { get; set; }
        public List<ModuloDto> Modules { get; set; }
        public List<VistaDto> Views { get; set; }
    }
}
