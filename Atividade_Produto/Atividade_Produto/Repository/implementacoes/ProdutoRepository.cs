using Atividade_Produto.Context;
using Atividade_Produto.Models;
using Atividade_Produto.Repository.interfaces;

namespace Atividade_Produto.Repository.implementacoes
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ContextProduto context) : base(context) { }

        //public async Task<Cliente> FindByName(string Name)
        //{
        //    return await _context.Cliente
        //        .Where(cli => EF.Functions.Like(cli.Nome, "%"+Name+"%"))
        //        .SingleOrDefaultAsync();
        //}
    }
}
