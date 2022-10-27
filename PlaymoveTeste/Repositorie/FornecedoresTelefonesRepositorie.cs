using PlaymoveTeste.DataContext;
using PlaymoveTeste.Model;

namespace PlaymoveTeste.Repositorie
{
    public class FornecedoresTelefonesRepositorie : IFornecedoresTelefonesRepositorie
    {
        private readonly AppDbContext? _context;

        public FornecedoresTelefonesRepositorie(AppDbContext context)
        {
            _context = context;
        }
        public List<FornecedoresTelefonesModel> GetByFornecedor(int FornecedorId)
        {
            try
            {
                return _context.FornecedoresTelefones.Where(ft => ft.FornecedorId == FornecedorId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public FornecedoresTelefonesModel Delete(int id)
        {
            try
            {
                FornecedoresTelefonesModel fornecedorTelefoneDelete = GetById(id);
                _context.FornecedoresTelefones.Remove(fornecedorTelefoneDelete);
                if (_context.SaveChanges() > 0)
                    return fornecedorTelefoneDelete;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FornecedoresTelefonesModel> GetAll()
        {
            try
            {
                return _context.FornecedoresTelefones.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public FornecedoresTelefonesModel GetById(int id)
        {
            try
            {
                if (id > 0)
                    return _context.FornecedoresTelefones.FirstOrDefault(ft => ft.Id == id);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public FornecedoresTelefonesModel Insert(FornecedoresTelefonesModel model)
        {
            try
            {
                _context.FornecedoresTelefones.Add(model);
                if (_context.SaveChanges() > 0)
                    return model;
                else
                    return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public FornecedoresTelefonesModel Update(int id, FornecedoresTelefonesModel model)
        {
            try
            {
                FornecedoresTelefonesModel fornecedorTelefoneUpdate = GetById(id);
                fornecedorTelefoneUpdate.Telefone = model.Telefone;
                fornecedorTelefoneUpdate.FornecedorId = model.FornecedorId;
                _context.FornecedoresTelefones.Update(fornecedorTelefoneUpdate);
                if (_context.SaveChanges() > 0)
                    return model;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
