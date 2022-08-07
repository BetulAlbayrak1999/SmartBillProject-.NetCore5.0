using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApartmentValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.ApartmentRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.AppartmentServices
{
    public class ApartmentService : GenericService<CreateApartmentRequestDto, CreateApartmentRequestValidator, GetApartmentRequestDto, GetAllApartmentRequestDto, Apartment>, IApartmentService
    {
        #region Field and Ctor
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _autoMapper;
        public ApartmentService(IMapper autoMapper, IApartmentRepository apartmentRepository) : base(autoMapper, apartmentRepository)
        {
            _autoMapper = autoMapper;
            _apartmentRepository = apartmentRepository;
        }

        #endregion

        public Task<CommandResponse> Activate(int Id)
        {
            throw new NotImplementedException();
        }

        #region GetAllActivated
        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllActivated()
        {
            try
            {
                IEnumerable<Apartment> items = await _apartmentRepository.GetAllByAsync(x => x.IsActive == true);

                IEnumerable<GetAllApartmentRequestDto> result = _autoMapper.Map<IEnumerable<Apartment>, IEnumerable<GetAllApartmentRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllUnActivated()
        {
            try
            {
                IEnumerable<Apartment> items = await _apartmentRepository.GetAllByAsync(x => x.IsActive == false);

                IEnumerable<GetAllApartmentRequestDto> result = _autoMapper.Map<IEnumerable<Apartment>, IEnumerable<GetAllApartmentRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<CommandResponse> UnActivate(int Id)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Update

        public async Task<CommandResponse> Update(UpdateApartmentRequestDto item)
        {
            try
            {
                var getItem = await _apartmentRepository.GetByIdAsync(item.Id);
                if (item is not null && getItem is not null)
                {
                    //validation
                    var validator = new UpdateApartmentRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //set last modify time
                    //mapping
                    Apartment mappedItem = _autoMapper.Map<Apartment>(item);
                    if (item.IsActive == false && getItem.IsActive == true)
                    {
                        mappedItem.UnActivedDate = DateTime.Now;
                        mappedItem.ActivedDate = null;
                    }
                    else if(item.IsActive == true && getItem.IsActive ==false)
                    {
                        mappedItem.ActivedDate = DateTime.Now;
                        mappedItem.UnActivedDate = null;
                    }
                    if (item.PersonsNumber == 0)
                        item.IsEmpty = true;
                    else { item.IsEmpty = false; }

                    bool IsUpdated = await _apartmentRepository.UpdateAsync(mappedItem);
                    if(IsUpdated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message}; }

        }
        #endregion

       
    }

}