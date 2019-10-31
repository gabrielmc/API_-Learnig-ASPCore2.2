using Atividade_Garagem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_Garagem.Business.interfaces
{
    public interface IClienteBusiness
    {
        Task<ICollection<Cliente>> FindAll();
        Task<Cliente> Create(Cliente obj);
        Task<Cliente> Update(Cliente obj);
        Task<Cliente> FindById(int id);
        Task<Cliente> FindByCPF(string cpf);
        Task<Cliente> FindByName(string name);
        Task Delete(int id);
    }
}