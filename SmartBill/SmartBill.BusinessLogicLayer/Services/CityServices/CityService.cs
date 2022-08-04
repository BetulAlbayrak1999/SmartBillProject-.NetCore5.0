using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.CityDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CityServices
{
    public class CityService : ICityService
    {
        public Task<CommandResponse> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Create(CreateCityRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllCityRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllCityRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<GetCityRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Update(UpdateCityRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
