using PlaymoveTeste.DataContext;
using PlaymoveTeste.Model;
using Microsoft.EntityFrameworkCore;

namespace PlaymoveTeste.Repositorie
{
    public class FornecedoresRepostorie : IFornecedoresRepositorie
    {
        private readonly AppDbContext? _context;

        public FornecedoresRepostorie(AppDbContext context)
        {
            _context = context;
        }
        public FornecedoresModel Delete(int id)
        {
            try
            {
                FornecedoresModel fornecedorDelete = GetById(id);
                _context.Fornecedores.Remove(fornecedorDelete);
                if (_context.SaveChanges() > 0)
                    return fornecedorDelete;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FornecedoresModel> GetAll()
        {
            try
            {
                return _context.Fornecedores.Include(f => f.Telefones).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public FornecedoresModel GetById(int id)
        {
            try
            {
                if (id > 0)
                    return _context.Fornecedores.Include(f => f.Telefones).FirstOrDefault(f => f.Id == id);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

       

        public FornecedoresModel Insert(FornecedoresModel model)
        {
            try
            {
                _context.Fornecedores.Add(model);
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

        public FornecedoresModel Update(int id, FornecedoresModel model)
        {
            try
            {
                FornecedoresModel fornecedorUpdate = GetById(id);
                fornecedorUpdate.RG = model.RG;
                fornecedorUpdate.Nascimento = model.Nascimento;
                fornecedorUpdate.EmpresaId = model.EmpresaId;
                fornecedorUpdate.Nome = model.Nome;
                fornecedorUpdate.Telefones = model.Telefones;
                fornecedorUpdate.CNPJ = model.CNPJ;
                fornecedorUpdate.CPF = model.CPF;
                fornecedorUpdate.Data_Hora_Cadatro = model.Data_Hora_Cadatro;

                _context.Fornecedores.Update(fornecedorUpdate);
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
