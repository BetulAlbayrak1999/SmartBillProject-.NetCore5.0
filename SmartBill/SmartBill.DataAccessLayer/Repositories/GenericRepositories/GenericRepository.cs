using Microsoft.EntityFrameworkCore;
using SmartBill.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.GenericRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Field and Constructor

        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _object;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _object = _context.Set<T>();
        }

        #endregion


        public async Task<bool> CreateAsync(T item)
        {
            try
            {
                _object.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<bool> DeleteAsync(string Id)
        {
            try
            {
                var item = await _object.FindAsync(Id);
                _object.Remove(item);
                return true;
            }catch(Exception ex) { return false; }
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _object.ToArrayAsync();
            }
            catch(Exception ex) { return Enumerable.Empty<T>(); }
        }

        public async Task<IEnumerable<T>> GetAllByAsync(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                    return await _object.ToArrayAsync();

                return _object.Where(predicate);
            }catch(Exception ex)
            {
                return Enumerable.Empty<T>();
            }
            
        }
        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                if (predicate == null)
                    return null;
                return await _object.FindAsync(predicate);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<T> GetByIdAsync(string Id)
        {
            try
            {
                return await _object.FindAsync(Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(T item)
        {
            try
            {
                _object.Update(item);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
