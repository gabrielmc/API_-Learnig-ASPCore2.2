using Atividade_Garagem.Business.interfaces;
using Atividade_Garagem.Models;
using Atividade_Garagem.Repository.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_Garagem.Business.implementacoes
{
    public class ClienteBusiness : IClienteBusiness
    {
        private IClienteRepository _repository;

        public ClienteBusiness(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cliente> Create(Cliente obj)
        {
            return await _repository.Create(obj);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ICollection<Cliente>> FindAll()
        {
            return await _repository.FindAll();
        }

        public async Task<Cliente> FindById(int id)
        {
            return await _repository.FindById(id);
        }

        public async Task<Cliente> Update(Cliente obj)
        {
            return await _repository.Update(obj);
        }
    }
}
