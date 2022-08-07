﻿using AutoMapper;
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

        #region Activate
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                Apartment apart = await _apartmentRepository.GetByIdAsync(Id);
                if (apart == null)
                    return null;
                apart.IsActive = true;
                apart.ActivedDate = DateTime.Now;
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
                apart.UnActivedDate = DateTime.Now;
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