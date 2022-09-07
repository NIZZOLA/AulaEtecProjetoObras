namespace Obra.API.Contracts.Response
{
    public class TipoDeReceitaDespesaResponseModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public bool Receita { get; set; }
        public bool Despesa { get; set; }

    }
}
