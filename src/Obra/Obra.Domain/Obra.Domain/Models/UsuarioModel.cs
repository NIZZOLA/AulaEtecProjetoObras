using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Domain.Models
{
    [Table("Usuario")]
    public class UsuarioModel: IdentityUser
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public PerfilDeUsuarioEnum Perfil { get; set; }
    }
}
