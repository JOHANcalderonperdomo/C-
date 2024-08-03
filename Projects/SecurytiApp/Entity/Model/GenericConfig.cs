using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Model
{
    internal class GenericConfig
    {
        public void ConfigureUsuario(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(i => i.nombre_de_usuario).IsUnique();
        }
        public void ConfigurePersona(EntityTypeBuilder<Persona> builder)
        {
            builder.HasIndex(i => i.correo).IsUnique();
            builder.HasIndex(i => i.documento).IsUnique();
        }
    }
}
