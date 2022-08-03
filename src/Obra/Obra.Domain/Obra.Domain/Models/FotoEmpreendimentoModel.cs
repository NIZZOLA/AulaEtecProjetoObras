using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obra.Domain.Models
{
    public class FotoEmpreendimentoModel : BaseModel
    {
        [ForeignKey("Empreendimento")]
        public Guid? EmpreendimentoId { get; set; }
        public EmpreendimentoModel Empreendimento { get; set; }

        public string NomeDoArquivo { get; set; }
    }
}
