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
    public class EmpreendimentoModel : BaseModel
    {
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Nome { get; set; }

        [ForeignKey("Cliente")]
        public Guid? ClienteId { get; set; }
        public ClienteFornecedorModel? Cliente { get; set; }

        public DateTime DataOrcamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevistaTermino { get; set; }
        public DateTime? DataTermino { get; set; }


        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Bairro { get; set; }

        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Estado { get; set; }

        [MaxLength(10, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cep { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
