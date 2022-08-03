using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Domain.Models
{
    public class BaseModel
    {
        [Key]
        public Guid? Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataCriacao { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UsuarioIdCriacao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? DataAlteracao { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UsuarioIdAlteracao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime? DataExclusao { get; set; }
        [ScaffoldColumn(false)]
        public Guid? UsuarioIdExclusao { get; set; }
    }
}
