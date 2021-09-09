using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portafolio.WebApi.PersistenciaDatos.Repository
{
    public interface IRepository
    {
        Task<List<T>> GetAllCondition<T>(Expression<Func<T, bool>> t) where T : class;
        Task<List<T>> GetAll<T>() where T : class;
        Task CreatedAsync<T>(T entity) where T : class;
        Task UpdateAsync<T>(T update, T entity) where T : class;
        Task DeleteAsync<T>(T entity) where T : class;
        Task<T> FindByEx<T>(Expression<Func<T, bool>> t) where T : class;
    }
}
