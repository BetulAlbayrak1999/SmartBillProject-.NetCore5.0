using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
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



        #region Create
        public async Task<bool> Create(CreateApartmentRequestDto item)
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
                    var IsCreated = await _apartmentRepository.Create(mappedItem);
                    if(IsCreated == true)
                        return true; 
                    return false;
                }

                { return false; }

            }
            catch (Exception ex) { return false; }
        }

        #endregion


        #region GetAllActivated
        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllActivated()
        {
            try
            {
                IEnumerable<Apartment> items = await _apartmentRepository.GetAll();

                IEnumerable<GetAllApartmentRequestDto> result = items.Where(d => d.IsActive == true).Select(d => new GetAllApartmentRequestDto
                {
                    Id = d.Id,
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


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllApartmentRequestDto>> GetAllUnActivated()
        {
            try
            {
                IEnumerable<Apartment> items = await _apartmentRepository.GetAll();

                IEnumerable<GetAllApartmentRequestDto> result = items.Where(d => d.IsActive == false).Select(d => new GetAllApartmentRequestDto
                {
                    Id= d.Id,
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


        #region Update

        public async Task<bool> Update(UpdateApartmentRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new UpdateApartmentRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //set last modify time
                    //mapping
                    Apartment mappedItem = _autoMapper.Map<Apartment>(item);
                    if (item.IsActive == false)
                    {
                        mappedItem.UnActivedDate = DateTime.Now;
                        mappedItem.ActivedDate = null;
                    }
                    else if(item.IsActive == true)
                    {
                        mappedItem.ActivedDate = DateTime.Now;
                        mappedItem.UnActivedDate = null;
                    }
                    if (item.PersonsNumber == 0)
                        item.IsEmpty = true;
                    else { item.IsEmpty = false; }

                    bool IsUpdated = await _apartmentRepository.Update(mappedItem);
                    if(IsUpdated == true)
                        return true;

                    return false;
                }

                { return false; }

            }
            catch (Exception ex) { return false; }

        }


        #endregion
    }
}