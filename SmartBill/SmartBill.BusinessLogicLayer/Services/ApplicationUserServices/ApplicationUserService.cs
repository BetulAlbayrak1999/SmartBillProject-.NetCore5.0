using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.ApplicationUserServices
{
    public class ApplicationUserService : IApplicationUserService
    {
        public Task<CommandResponse> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Create(CreateApplicationUserRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActive()
        {
            throw new NotImplementedException();
        }

        public Task<GetApplicationUserRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Update(UpdateApplicationUserRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
