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
        public Task<bool> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(CreateApplicationUserRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<GetApplicationUserRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateApplicationUserRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
