namespace Hair.Application.ApiRequest.Entities
{
    /// <summary>
    /// Entidade da API para busca do CEP
    /// </summary>
    internal class CepEntity
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
    }
}