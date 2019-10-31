using Atividade_Garagem.Business.interfaces;
using Atividade_Garagem.Models;
using Atividade_Garagem.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_Garagem.Business.implementacoes
{
    public class ServicoBusiness : IServicoBusiness
    {
        private IServicoRepository _repository;

        public ServicoBusiness(IServicoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Servico> Create(Servico obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Servico>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Servico> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Servico> FindByIdWithCliente(int id)
        {
            return await _repository.FindByIdWithCliente(id);
        }

        public async Task<Servico> Update(Servico obj)
        {
            return await _repository.Update(obj);
        }
    }
}
