using PlaymoveTeste.Model;

namespace PlaymoveTeste.Repositorie
{
    public interface IFornecedoresTelefonesRepositorie
    {
        public List<FornecedoresTelefonesModel> GetAll();
        public FornecedoresTelefonesModel GetById(int id);
        public FornecedoresTelefonesModel GetByFornecedor(int FornecedorId);
        public FornecedoresTelefonesModel Update(int id, FornecedoresTelefonesModel model); 
        public FornecedoresTelefonesModel Delete(int id);
        public FornecedoresTelefonesModel Insert(FornecedoresTelefonesModel model);
    }
}
