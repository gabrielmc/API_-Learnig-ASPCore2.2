using System;
using Atividade_Produto.Context;
using Atividade_Produto.Models.Base;
using Atividade_Produto.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Atividade_Produto.Repository.implementacoes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ContextProduto _context;
        private DbSet<T> dataset;

        public GenericRepository(ContextProduto context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public virtual async Task<T> Create(T item)
        {
            try
            {
                dataset.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    int codigoErro = sqlException.Number;
                    if (codigoErro.Equals(2627) || codigoErro.Equals(2601))
                        throw new InvalidOperationException("O recurso já existe!");
                    if (codigoErro.Equals(547))
                        throw new InvalidOperationException("Chave Estrangeira inválida!");
                }
                throw ex;
            }
        }

        public async Task<T> Delete(int id)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    throw new Exception("O recurso não foi encontrado para exclusão");

                _context.Entry(resultado).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<T>> FindAll()
        {
            return await dataset.ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public virtual async Task<T> Update(T item)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(item.Id));
            try
            {
                if (resultado == null)
                    throw new Exception("O item não existe");
                _context.Entry(resultado).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return resultado;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
