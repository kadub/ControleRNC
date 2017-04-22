using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ControleRNC_WEB.Models;

namespace ControleRNC_WEB.DataAcessLayer
{
    public class ControleRncContext : DbContext
    {
        public ControleRncContext() : base("ControleRncContext")
        {
            
        }

        public DbSet<TipoRnc> TipoRncs { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Rnc> Rncs { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ProdutoEstoque> ProdutoEstoques { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<TipoAcao> TiposAcao { get; set; }
        public DbSet<TipoStatus> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}