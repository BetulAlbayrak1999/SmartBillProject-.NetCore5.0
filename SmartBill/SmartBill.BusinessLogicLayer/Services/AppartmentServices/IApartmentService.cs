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
    public interface IApartmentService : IGenericService<Apartment>
    {
        public Task<IEnumerable<GetAllApartmentRequestDto>> GetAllActivatedAsync();

        public Task<IEnumerable<GetAllApartmentRequestDto>> GetAllUnActivatedAsync();

        public Task<IEnumerable<GetAllApartmentRequestDto>> GetAllAsync();

        public Task<CommandResponse> UpdateAsync(UpdateApartmentRequestDto item);

        public Task<CommandResponse> ActivateAsync(string Id);

        public Task<CommandResponse> UnActivateAsync(string Id);
        public Task<GetApartmentRequestDto> GetByIdAsync(string Id);

        public Task<CommandResponse> CreateAsync(CreateApartmentRequestDto item);

    }
}

