using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.MessageDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;

using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        public Task<CommandResponse> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Create(CreateMessageRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllMessageRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllMessageRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<GetMessageRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResponse> Update(UpdateMessageRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
