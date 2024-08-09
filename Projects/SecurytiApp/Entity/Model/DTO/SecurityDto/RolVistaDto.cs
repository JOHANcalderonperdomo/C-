using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.DTO.SecurityDto
{
    public class RolVistaDto
    {
        public int Id { get; set; }
        public int rolId { get; set; }
        public int vistaId { get; set; }

        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? deleted_at { get; set; }
        public bool state { get; set; }
    }
}
