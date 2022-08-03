using SmartBill.BusinessLogicLayer.Configrations.Responses;
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
        public Task<CommandResponse> Create(TCreate item);

        public Task<CommandResponse> UnActivate(string Id);
        public Task<CommandResponse> Activate(string Id);

        public Task<CommandResponse> Update(TUpdate item);

        public Task<IEnumerable<TGetAll>> GetAllUnActive();
        public Task<IEnumerable<TGetAll>> GetAllActive();

        public Task<TGet> GetById(string Id);
    }
}
