using PlaymoveTeste.Model;

namespace PlaymoveTeste.Repositorie
{
    public interface IFornecedoresRepositorie
    {
        public List<FornecedoresModel> GetAll();
        public FornecedoresModel GetById(int id);
        public FornecedoresModel Update(int id, FornecedoresModel model); 
        public FornecedoresModel Delete(int id);
        public FornecedoresModel Insert(FornecedoresModel model);
    }
}
