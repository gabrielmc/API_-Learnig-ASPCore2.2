using Atividade_Garagem.Context;
using Atividade_Garagem.Models;
using Atividade_Garagem.Repository.interfaces;

namespace Atividade_Garagem.Repository.implementacoes
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ExemploContext context) : base(context) { }

    }
}
