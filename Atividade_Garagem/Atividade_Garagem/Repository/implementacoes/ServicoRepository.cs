using Atividade_Garagem.Context;
using Atividade_Garagem.Models;
using Atividade_Garagem.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Atividade_Garagem.Repository.implementacoes
{
    public class ServicoRepository : GenericRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(ExemploContext context) : base(context) { }

        public async Task<Servico> FindByIdWithCliente(int Id)
        {
            return await _context.Servico
                .Include(servico => servico.Cliente)
                .SingleOrDefaultAsync(p => p.Id.Equals(Id));
        }
    }
}
