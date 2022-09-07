namespace Obra.API.Contracts.Response
{
    public class FotoResponseModel
    {
        public Guid? EmpreendimentoId { get; set; }
        public string? Descricao { get; set; }
        public string NomeDoArquivo { get; set; }
        public Guid? Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public Guid? UsuarioIdCriacao { get; set; }
    }
}
