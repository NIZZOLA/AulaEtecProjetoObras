namespace Obra.API.Contracts.Response
{
    public class ContaResponseModel
    {
        public Guid? Id { get; set; }
        public Guid? EmpreendimentoId { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime? DataDoPagamento { get; set; }
        public DateTime? DataDaCompra { get; set; }

        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; }
        public string NumeroDoDocumento { get; set; }
        public string Observacoes { get; set; }
        public Guid? TipoDeDespesaId { get; set; }
        public TipoDeReceitaDespesaResponseModel? TipoDeDespesaReceita { get; set; }
        public Guid? TipoDePagamentoId { get; set; }
        public TipoDePagamentoResponseModel? TipoDePagamento { get; set; }
    }
}
