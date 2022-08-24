using Obra.API.Contacts.Requests;
using Obra.Domain.Models;

namespace Obra.API.Extensions
{
    public static class ContaRequestModelExtensions
    {
        public static ContaModel ToContaModel(this ContaRequestModel conta)
        {
            var obj = new ContaModel()
            {
                DataDoPagamento = conta.DataDoPagamento,
                DataCriacao = DateTime.Now,
                DataDaCompra = conta.DataDaCompra,
                EmpreendimentoId = conta.EmpreendimentoId,
                NumeroDoDocumento = conta.NumeroDoDocumento,
                Observacoes = conta.Observacoes,
                TipoDeDespesaId = conta.TipoDeDespesaId,
                TipoDePagamentoId = conta.TipoDePagamentoId,
                Valor = conta.Valor,
                ValorPago = conta.ValorPago,
                Vencimento = conta.Vencimento
            };
            return obj;
        }
    }
}
