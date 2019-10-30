using Atividade_Garagem.Context;
using Atividade_Garagem.Models;
using Atividade_Garagem.Repository.interfaces;

namespace Atividade_Garagem.Repository.implementacoes
{
    public class ServicoRepository : GenericRepository<Servico>, IServicoRepository
    {
        public ServicoRepository(ExemploContext context) : base(context) { }

    }
}
