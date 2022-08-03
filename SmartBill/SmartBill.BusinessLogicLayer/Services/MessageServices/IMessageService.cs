using SmartBill.BusinessLogicLayer.Dtos.MessageDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.MessageServices
{
    public interface IMessageService : IGenericService<CreateMessageRequestDto, UpdateMessageRequestDto, GetAllMessageRequestDto, GetMessageRequestDto>
    {
    }
}
