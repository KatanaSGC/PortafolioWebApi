using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio.WebApi.PersistenciaDatos.Repository
{
    public class Repository<PortafolioContext> : IRepository where PortafolioContext : DbContext
    {
        private readonly PortafolioContext _context;

        public Repository(PortafolioContext context)
        {
            _context = context;
        }

        public async Task CreatedAsync<T>(T entity) where T : class
        {
            this._context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Count<T>(Expression<Func<T, bool>> t) where T : class
        {
            return await _context.Set<T>().CountAsync(t);
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> FindByEx<T>(Expression<Func<T, bool>> t) where T : class
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t);
        }

        public async Task UpdateAsync<T>(T update, T entity) where T : class
        {
            _context.Entry(entity).CurrentValues.SetValues(update);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllCondition<T>(Expression<Func<T, bool>> t) where T : class
        {
            return await _context.Set<T>().Where(t).ToListAsync();
        }
    }
}
