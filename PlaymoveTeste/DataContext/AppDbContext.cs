using Microsoft.EntityFrameworkCore;
using PlaymoveTeste.Model;

namespace PlaymoveTeste.DataContext
{
    public class AppDbContext:DbContext
    {
        //Declarando classe de contexto para mapeamento do banco de dados com a classe.
        //A paritr dessa classe será criado as migrations
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<EmpresasModel>? Empresas { get; set; }
        public DbSet<FornecedoresModel>? Fornecedores { get; set; }
        public DbSet<FornecedoresTelefonesModel>? FornecedoresTelefones { get; set; }   
    }
}
