using PlaymoveTeste.Model;

namespace PlaymoveTeste.Repositorie
{
    //Interface para servir como contrato para os repositorios
    public interface IEmpresasRepositorie
    {
        public List<EmpresasModel> GetAll();
        public EmpresasModel GetById(int id);

        public EmpresasModel Update(int id, EmpresasModel model); 
        public EmpresasModel Delete(int id);
        public EmpresasModel Insert(EmpresasModel model);
        public List<EmpresasModel> GetEmpresaForneceores();
        public EmpresasModel GetEmpresaForneceoresById(int id);
    }
}
