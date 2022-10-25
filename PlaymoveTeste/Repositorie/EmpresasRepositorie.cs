using PlaymoveTeste.DataContext;
using PlaymoveTeste.Model;
using Microsoft.EntityFrameworkCore;

namespace PlaymoveTeste.Repositorie
{
    //Implementando Contrato da Interface no repositorio
    public class EmpresasRepositorie : IEmpresasRepositorie
    {
        private readonly AppDbContext? _context;

        public EmpresasRepositorie(AppDbContext context)
        {
            _context = context;
        }
        public EmpresasModel Delete(int id)
        {
            try
            {
                EmpresasModel empresaDelete = GetById(id);
                _context.Empresas.Remove(empresaDelete);
                if (_context.SaveChanges() > 0)
                    return empresaDelete;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<EmpresasModel> GetAll()
        {
            try
            {
                return _context.Empresas.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EmpresasModel GetById(int id)
        {
            try
            {
                if (id > 0)
                    return _context.Empresas.FirstOrDefault(e => e.Id == id);
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<EmpresasModel> GetEmpresaForneceores()
        {
            try
            {
                return _context.Empresas.Include(f => f.Fornecedores).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EmpresasModel GetEmpresaForneceoresById(int id)
        {
            try
            {
                return _context.Empresas.Include(f => f.Fornecedores).FirstOrDefault(e => e.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public EmpresasModel Insert(EmpresasModel model)
        {
            try
            {
                _context.Empresas.Add(model);
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

        public EmpresasModel Update(int id, EmpresasModel model)
        {
            try
            {
                EmpresasModel empresaUpdate = GetById(id);
                empresaUpdate.UF = model.UF;
                empresaUpdate.CNPJ = model.CNPJ;
                empresaUpdate.Nome_Fatansia = model.Nome_Fatansia;
                _context.Empresas.Update(empresaUpdate);
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
