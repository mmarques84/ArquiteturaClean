namespace DDD.Web.Models
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNasc { get; set; }
        public int Documento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
