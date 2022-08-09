using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.Entities.Domains;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.LocationServices
{
    public interface ILocationService : IGenericService<Location>
    {
        public Task<IEnumerable<GetAllLocationRequestDto>> GetAllActivatedAsync();

        public Task<IEnumerable<GetAllLocationRequestDto>> GetAllUnActivatedAsync();

        public Task<IEnumerable<GetAllLocationRequestDto>> GetAllAsync();

        public Task<CommandResponse> UpdateAsync(UpdateLocationRequestDto item);

        public Task<CommandResponse> ActivateAsync(string Id);

        public Task<CommandResponse> UnActivateAsync(string Id);

        public Task<CommandResponse> CreateAsync(CreateLocationRequestDto item);
        public Task<GetLocationRequestDto> GetByIdAsync(string Id);
        
    }
}
