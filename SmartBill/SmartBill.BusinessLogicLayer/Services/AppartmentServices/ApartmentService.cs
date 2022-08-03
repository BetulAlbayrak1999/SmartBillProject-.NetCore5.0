using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApartmentValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.ApartmentRepositories;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.AppartmentServices
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _autoMapper;
        public ApartmentService(IApartmentRepository apartmentRepository, IMapper autoMapper)
        {
            _apartmentRepository = apartmentRepository;
            _autoMapper = autoMapper;
        }

        #region Activate
        public async Task<CommandResponse> Activate(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    Apartment item = await _apartmentRepository.GetById(Id);
                    if (item != null)
                    {
                        item.IsActive = true;
                        await _apartmentRepository.Update(item);

                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
                    }

                    { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }
                }
                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }
            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

        }

        #endregion


        #region Create
        public async Task<CommandResponse> Create(CreateApartmentRequestDto item)
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
                    await _apartmentRepository.Create(mappedItem);
                    return new CommandResponse { Status = true, Message = "This operation has done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }
        }

        #endregion


        #region GetAllActive
        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllActive()
        {
            try
            {
                IEnumerable<Apartment> items = await _apartmentRepository.GetAll();

                IEnumerable<GetAllApartmentRequestDto> result = items.Where(d => d.IsActive == true).Select(d => new GetAllApartmentRequestDto
                {
                    Name = d.Name,
                    IsEmpty = d.IsEmpty,
                    PersonsNumber = d.PersonsNumber,
                    FloorNo = d.FloorNo,
                    BlockNo = d.BlockNo,
                    ApartmentNo = d.ApartmentNo,
                    LocationId = d.LocationId,
                    IsActive = d.IsActive

                });
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActive

        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllUnActive()
        {
            try
            {
                IEnumerable<Apartment> items = await _apartmentRepository.GetAll();

                IEnumerable<GetAllApartmentRequestDto> result = items.Where(d => d.IsActive == false).Select(d => new GetAllApartmentRequestDto
                {
                    Name = d.Name,
                    IsEmpty = d.IsEmpty,
                    PersonsNumber = d.PersonsNumber,
                    FloorNo = d.FloorNo,
                    BlockNo = d.BlockNo,
                    ApartmentNo = d.ApartmentNo,
                    LocationId = d.LocationId,
                    IsActive = d.IsActive

                });
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion


        #region GetById

        public async Task<GetApartmentRequestDto> GetById(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    Apartment item = await _apartmentRepository.GetById(Id);
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


        #region UnActivate
        public async Task<CommandResponse> UnActivate(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    Apartment item = await _apartmentRepository.GetById(Id);
                    if (item != null)
                    {
                        item.IsActive = false;
                        await _apartmentRepository.Update(item);

                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
                    }

                    { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }
                }
                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }
            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

        }


        #endregion


        #region Update

        public async Task<CommandResponse> Update(UpdateApartmentRequestDto item)
        {
            try
            {
                if (item is not null || GetById(item.Id) is not null)
                {
                    //validation
                    var validator = new UpdateApartmentRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    //mapping
                    Apartment mappedItem = _autoMapper.Map<Apartment>(item);

                    await _apartmentRepository.Update(mappedItem);
                    return new CommandResponse { Status = true, Message = "This operation has done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

        }


        #endregion
    }
}