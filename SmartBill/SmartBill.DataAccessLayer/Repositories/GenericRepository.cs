using Microsoft.EntityFrameworkCore;
using SmartBill.DataAccessLayer.Abstract;
using SmartBill.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        DbSet<T> _object;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _object = _context.Set<T>();
        }

        public async Task<bool> Create(T item)
        {
            try
            {
                _object.Add(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public async Task<bool> Delete(T item)
        {
            try
            {
                _object.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _object.ToArrayAsync();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T> GetById(int Id)
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

        public async Task<bool> Update(T item)
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
