using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.DTO.LocationDto
{
    public class DepartmentDto
    {
        public int id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Boolean estado { get; set; }

        //conexión con country
        public int countryId { get; set; }
    }
}
