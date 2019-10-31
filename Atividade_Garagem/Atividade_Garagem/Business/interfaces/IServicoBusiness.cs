using Atividade_Garagem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_Garagem.Business.interfaces
{
    public interface IServicoBusiness
    {
        Task<Servico> FindByIdWithCliente(int id);
        Task<ICollection<Servico>> FindAll();
        Task<Servico> Create(Servico obj);
        Task<Servico> Update(Servico obj);
        Task<Servico> FindById(int id);
        Task Delete(int id);
    }
}
