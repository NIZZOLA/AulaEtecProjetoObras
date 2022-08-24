namespace Obra.API.Contracts.Response
{
    public class EmpreendimentoResponseModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
    
        public ClienteResponseModel? Cliente { get; set; }

        public DateTime DataOrcamento { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrevistaTermino { get; set; }
        public DateTime? DataTermino { get; set; }

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
