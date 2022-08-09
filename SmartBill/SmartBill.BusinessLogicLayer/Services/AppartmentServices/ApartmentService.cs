using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApartmentValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.ApartmentRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.AppartmentServices
{
    public class ApartmentService : GenericService<Apartment>, IApartmentService
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

        #region Activate
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                Apartment apart = await _apartmentRepository.GetByIdAsync(Id);
                if (apart == null)
                    return null;
                apart.IsActive = true;
                apart.ActivatedDate = DateTime.Now;
                bool IsUpdated = await _apartmentRepository.UpdateAsync(apart);
                if (IsUpdated)
                    return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
            }
            catch (Exception ex)
            {
                return new CommandResponse { Status = false, Message = ex.Message };
            }
        }
        #endregion


        #region UnActivate
        public async Task<CommandResponse> UnActivateAsync(string Id)
        {
            try
            {
                Apartment apart = await _apartmentRepository.GetByIdAsync(Id);
                if (apart == null)
                    return null;
                apart.IsActive = false;
                apart.UnActivatedDate = DateTime.Now;
                bool IsUpdated = await _apartmentRepository.UpdateAsync(apart);
                if (IsUpdated)
                    return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
            }
            catch (Exception ex)
            {
                return new CommandResponse { Status = false, Message = ex.Message };
            }
        }
        #endregion



        #region GetAll
        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<Apartment> items = await _apartmentRepository.GetAllByAsync();
                IEnumerable<GetAllApartmentRequestDto> result = _autoMapper.Map<IEnumerable<Apartment>, IEnumerable<GetAllApartmentRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region GetAllActivated
        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllActivatedAsync()
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

        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllUnActivatedAsync()
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

        
        #endregion


        #region Update

        public async Task<CommandResponse> UpdateAsync(UpdateApartmentRequestDto item)
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
                        mappedItem.UnActivatedDate = DateTime.Now;
                        mappedItem.ActivatedDate = null;
                    }
                    else if(item.IsActive == true && getItem.IsActive ==false)
                    {
                        mappedItem.ActivatedDate = DateTime.Now;
                        mappedItem.UnActivatedDate = null;
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


        #region Create
        public async Task<CommandResponse> CreateAsync(CreateApartmentRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new CreateApartmentRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    //mapping
                    Apartment mappedItem = _autoMapper.Map<Apartment>(item);
                    var IsCreated = await _apartmentRepository.CreateAsync(mappedItem);
                    if (IsCreated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }
        }

        #endregion

        #region GetByIdAsync
        public async Task<GetApartmentRequestDto> GetByIdAsync(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    Apartment item = await _apartmentRepository.GetByIdAsync(Id);
                    if (item is not null)
                    {
                        //mapping
                        GetApartmentRequestDto mappedItem = _autoMapper.Map<GetApartmentRequestDto>(item);

                        return mappedItem;
                    }
                    return null;
                }

                { return null; }

            }
            catch (Exception ex) { return null; }
        }

        #endregion
    }

}