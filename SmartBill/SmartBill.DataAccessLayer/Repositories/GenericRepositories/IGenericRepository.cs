using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.GenericRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> CreateAsync(T item);

        Task<bool> UpdateAsync(T item);

        Task<bool> DeleteAsync(string Id);

        Task<T> GetByAsync(Expression<Func<T, bool>> predicate = null);

        Task<IEnumerable<T>> GetAllAsync();/// <summary>
        /// olabilir olmaya da bilir
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        Task<T> GetByIdAsync(string Id);

        Task<IEnumerable<T>> GetAllByAsync(Expression<Func<T, bool>> predicate = null);
    }
}
