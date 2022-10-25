using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace PlaymoveTeste.Model
{
    public class EmpresasModel
    {
        //Declarando Entidade Modelo para o entity Framework
        public EmpresasModel()
        {
            Fornecedores = new Collection<FornecedoresModel>();
        }
        public int Id { get; set; }
        public string? Nome_Fatansia { get; set; }   
        public string? CNPJ { get; set; }
        public string? UF { get; set; }
        public ICollection<FornecedoresModel>? Fornecedores { get; set; }
    }
}
