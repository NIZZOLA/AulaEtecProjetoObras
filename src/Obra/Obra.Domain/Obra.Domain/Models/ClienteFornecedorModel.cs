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
    [Table("ClienteFornecedor")]
    public class ClienteFornecedorModel : BaseModel
    {
        public bool Cliente { get; set; }
        public bool Fornecedor { get; set; }

        #region Dados Pessoa Fisica
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Nome { get; set; }
        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cpf { get; set; }
        public DateTime? DataDeNascimento { get; set; }
        #endregion

        #region Pessoa Juridica
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string NomeFantasia { get; set; }
        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string RazaoSocial { get; set; }

        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cnpj { get; set; }
        [MaxLength(18, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string InscricaoEstadual { get; set; }
        public bool OptanteDoSimples { get; set; }
        #endregion

        public string? Observacoes { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        [MaxLength(50, ErrorMessage = "")]
        public string Bairro { get; set; }

        [MaxLength(50, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Cidade { get; set; }

        [MaxLength(2, ErrorMessage = MessageHelpers.MaxLenghtMessage)]
        public string Estado { get; set; }

        [MaxLength(10, ErrorMessage = "")]
        public string Cep { get; set; }
        
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<EmpreendimentoModel> Empreendimentos { get; set; }
    }
}