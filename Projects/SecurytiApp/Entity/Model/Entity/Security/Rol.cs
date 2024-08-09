using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Entity.Security
{
    public class Rol
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public ICollection<Rol_Vista> rol_Vistas_rol { get; set; }
        public ICollection<Usuario_rol> rol_usuario_rol { get; set; }

        public DateTime created_at { get; set; }

        public DateTime created_by { get; set; }

        public DateTime? updated_at { get; set; }

        public DateTime? updated_by { get; set; }

        public DateTime? deleted_at { get; set; }
        public DateTime? deleted_by { get; set; }

        public bool estado { get; set; }

    }
}
