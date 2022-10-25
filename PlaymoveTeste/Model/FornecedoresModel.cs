using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace PlaymoveTeste.Model
{
    public class FornecedoresModel
    {
        //Declarando Entidade Modelo para o entity Framework
        public FornecedoresModel()
        {
            Telefones = new Collection<FornecedoresTelefonesModel>();
        }
        public int Id { get; set; } 
        public string? Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? CPF { get; set; }
        public int EmpresaId { get; set; }
        [JsonIgnore]
        public EmpresasModel? Empresa { get; set; }
        public DateTime? Data_Hora_Cadatro { get; set; }
        public ICollection<FornecedoresTelefonesModel>? Telefones { get; set; }
    }
}
