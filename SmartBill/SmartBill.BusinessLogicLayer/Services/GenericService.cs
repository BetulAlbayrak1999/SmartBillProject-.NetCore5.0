using SmartBill.BusinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        public Task<bool> Create(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}