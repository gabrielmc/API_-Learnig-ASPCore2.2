using Atividade_Produto.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_Produto.Repository.interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> Create(T item);
        Task<T> Update(T item);
        Task<T> Delete(int id);
    }
}
