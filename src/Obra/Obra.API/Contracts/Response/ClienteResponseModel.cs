namespace Obra.API.Contracts.Response
{
    public class ClienteResponseModel
    {
        public Guid? Id { get; set; }

        public bool Cliente { get; set; }
        public bool Fornecedor { get; set; }
        public string Nome { get; set; }
        
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public string? Observacoes { get; set; }

        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        
    }
}
