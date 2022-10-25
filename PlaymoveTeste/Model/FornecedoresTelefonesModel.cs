using System.Text.Json.Serialization;

namespace PlaymoveTeste.Model
{
    public class FornecedoresTelefonesModel
    {
        public int Id { get; set; }
        public int FornecedorId { get; set; }
        [JsonIgnore]
        public FornecedoresModel? Fornecedor { get; set; }
        public string? Telefone { get; set; }
    }
}
