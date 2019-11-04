using System.Linq;
using System.Threading.Tasks;
using Atividade_Garagem.Context;
using Atividade_Garagem.Models;
using Atividade_Garagem.Repository.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Atividade_Garagem.Repository.implementacoes
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ExemploContext context) : base(context) { }

        public async Task<Cliente> FindByCPF(string CPF)
        {
            return await _context.Cliente
                .Where(cli => cli.CPF.Equals(CPF))
                .SingleOrDefaultAsync();
        }

        public async Task<Cliente> FindByName(string Name)
        {
            return await _context.Cliente
                .Where(cli => EF.Functions.Like(cli.Nome, "%"+Name+"%"))
                .SingleOrDefaultAsync();
        }
    }
}
