using Obra.Domain.Models;

namespace Obra.API.Contacts.Requests
{
    public class ContaRequestModel
    {
        public Guid? EmpreendimentoId { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime? DataDoPagamento { get; set; }
        public DateTime? DataDaCompra { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }
        public string? NumeroDoDocumento { get; set; }
        public string? Observacoes { get; set; }
        public Guid? TipoDeDespesaId { get; set; }
        public Guid? TipoDePagamentoId { get; set; }
    }
}
