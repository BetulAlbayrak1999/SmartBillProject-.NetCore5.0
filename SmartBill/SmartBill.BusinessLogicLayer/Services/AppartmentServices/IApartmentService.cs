using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApartmentValidators;
using SmartBill.DataAccessLayer.Repositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.AppartmentServices
{
    public interface IApartmentService : IGenericService<CreateApartmentRequestDto, CreateApartmentRequestValidator, GetApartmentRequestDto, GetAllApartmentRequestDto, Apartment>
    {
        public Task<IEnumerable<GetAllApartmentRequestDto>> GetAllActivated();

        public Task<IEnumerable<GetAllApartmentRequestDto>> GetAllUnActivated();

        public Task<CommandResponse> Update(UpdateApartmentRequestDto item);

        public Task<CommandResponse> Activate(int Id);
        public Task<CommandResponse> UnActivate(int Id);

    }
}
