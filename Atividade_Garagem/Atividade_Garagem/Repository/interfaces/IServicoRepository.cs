using Atividade_Garagem.Models;
using System.Threading.Tasks;

namespace Atividade_Garagem.Repository.interfaces
{
    public interface IServicoRepository : IGenericRepository<Servico>
    {
        Task<Servico> FindByIdWithCliente(int id);
    }
}
