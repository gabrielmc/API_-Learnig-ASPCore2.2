using Atividade_Garagem.Context;
using Atividade_Garagem.Models.Base;
using Atividade_Garagem.Repository.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atividade_Garagem.Repository.implementacoes
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ExemploContext _context;
        private DbSet<T> dataset;

        public GenericRepository(ExemploContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public virtual async Task<T> Create(T item)
        {
            dataset.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task Delete(int id)
        {
            var resultado = await dataset.SingleOrDefaultAsync(i => i.Id.Equals(id));
            try
            {
                if (resultado == null)
                    throw new Exception("Não existe este item");
                dataset.Remove(resultado);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
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
