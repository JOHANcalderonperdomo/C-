using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    public class PersonaDto
    {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Gender { get; set; }
            public string Document { get; set; }
            public string TypeDocument { get; set; }
            public string Direction { get; set; }
            public string Phone { get; set; }
            public DateTime Birthday { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime DeletedAt { get; set; }
            public bool State { get; set; }
        
    }
}
