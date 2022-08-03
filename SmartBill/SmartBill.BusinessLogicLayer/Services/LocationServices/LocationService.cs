using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.LocationServices
{
    public class LocationService : ILocationService
    {
        public Task<CommandResponse> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Create(CreateLocationRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllLocationRequestDto>> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllLocationRequestDto>> GetAllUnActive()
        {
            throw new NotImplementedException();
        }

        public Task<GetLocationRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Update(UpdateLocationRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
