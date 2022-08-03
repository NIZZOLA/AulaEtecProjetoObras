using Obra.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Domain.Models
{
    [Table("TipoDePagamento")]
    public class TipoDePagamentoModel : BaseModel
    {
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Nome { get; set; }

        public ICollection<ContaModel>? Contas { get; set; }
    }
}
