using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.GenericServices
{
    public interface IGenericService<TCreate, TUpdate, TGetAll, TGet>
        where TCreate : class, new()
        where TUpdate : class, new()
        where TGetAll : class, new()
        where TGet : class, new()
    {
        public Task<bool> Create(TCreate item);

        public Task<bool> Update(TUpdate item);

        public Task<IEnumerable<TGetAll>> GetAllUnActivated();
        public Task<IEnumerable<TGetAll>> GetAllActivated();

        public Task<TGet> GetById(string Id);
    }
}
