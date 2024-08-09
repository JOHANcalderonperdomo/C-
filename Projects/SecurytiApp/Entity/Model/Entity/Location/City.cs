using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Entity.Location
{
    public class City
    {
        public int id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public int departmentId { get; set; }
        public Department department { get; set; }


        public DateTime created_at { get; set; }

        public DateTime created_by { get; set; }

        public DateTime? updated_at { get; set; }

        public DateTime? updated_by { get; set; }

        public DateTime? deleted_at { get; set; }
        public DateTime? deleted_by { get; set; }

        public bool estado { get; set; }
    }
}
