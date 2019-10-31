using Atividade_Garagem.Models;
using System.Threading.Tasks;

namespace Atividade_Garagem.Repository.interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<Cliente> FindByCPF(string cpf);
        Task<Cliente> FindByName(string name);
    }
}
