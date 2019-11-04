using Atividade_Produto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Atividade_Produto.Context
{
    public class ContextProduto : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public DbSet<Produto> produto { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<ItensProduto> itensPedido { get; set; }

        public ContextProduto() { }

        public ContextProduto(DbContextOptions<ContextProduto> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
