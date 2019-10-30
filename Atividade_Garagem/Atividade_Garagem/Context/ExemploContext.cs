using Atividade_Garagem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Atividade_Garagem.Context
{
    public class ExemploContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Servico> Servico { get; set; }

        public ExemploContext() { }

        public ExemploContext(DbContextOptions<ExemploContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
