using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Repositories;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.AppartmentServices
{
    public interface IApartmentService : IGenericService<CreateApartmentRequestDto, UpdateApartmentRequestDto, GetAllApartmentRequestDto, GetApartmentRequestDto>
    {
    }
}
