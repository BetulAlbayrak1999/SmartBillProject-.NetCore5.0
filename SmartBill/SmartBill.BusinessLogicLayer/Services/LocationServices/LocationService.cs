using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.LocationValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.LocationRepositories;
using SmartBill.Entities.Domains;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.LocationServices
{
    public class LocationService : GenericService<Location>, ILocationService
    {
        #region Field and Ctor
        private readonly ILocationRepository _LocationRepository;
        private readonly IMapper _autoMapper;
        public LocationService(IMapper autoMapper, ILocationRepository LocationRepository) : base(autoMapper, LocationRepository)
        {
            _autoMapper = autoMapper;
            _LocationRepository = LocationRepository;
        }

        #endregion

        #region Activate
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                Location item = await _LocationRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = true;
                item.ActivatedDate = DateTime.Now;
                bool IsUpdated = await _LocationRepository.UpdateAsync(item);
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
                Location item = await _LocationRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = false;
                item.UnActivatedDate = DateTime.Now;
                bool IsUpdated = await _LocationRepository.UpdateAsync(item);
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
        public async Task<IEnumerable<GetAllLocationRequestDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<Location> items = await _LocationRepository.GetAllByAsync();
                IEnumerable<GetAllLocationRequestDto> result = _autoMapper.Map<IEnumerable<Location>, IEnumerable<GetAllLocationRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region GetAllActivated
        public async Task<IEnumerable<GetAllLocationRequestDto>> GetAllActivatedAsync()
        {
            try
            {
                IEnumerable<Location> items = await _LocationRepository.GetAllByAsync(x => x.IsActive == true);

                IEnumerable<GetAllLocationRequestDto> result = _autoMapper.Map<IEnumerable<Location>, IEnumerable<GetAllLocationRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllLocationRequestDto>> GetAllUnActivatedAsync()
        {
            try
            {
                IEnumerable<Location> items = await _LocationRepository.GetAllByAsync(x => x.IsActive == false);

                IEnumerable<GetAllLocationRequestDto> result = _autoMapper.Map<IEnumerable<Location>, IEnumerable<GetAllLocationRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion


        #region Update

        public async Task<CommandResponse> UpdateAsync(UpdateLocationRequestDto item)
        {
            try
            {
                var getItem = await _LocationRepository.GetByIdAsync(item.Id);
                if (item is not null && getItem is not null)
                {
                    //validation
                    var validator = new UpdateLocationRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //set last modify time
                    //mapping
                    Location mappedItem = _autoMapper.Map<Location>(item);
                    if (item.IsActive == false && getItem.IsActive == true)
                    {
                        mappedItem.UnActivatedDate = DateTime.Now;
                        mappedItem.ActivatedDate = null;
                    }
                    else if (item.IsActive == true && getItem.IsActive == false)
                    {
                        mappedItem.ActivatedDate = DateTime.Now;
                        mappedItem.UnActivatedDate = null;
                    }
                 

                    bool IsUpdated = await _LocationRepository.UpdateAsync(mappedItem);
                    if (IsUpdated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }

        }
        #endregion


        #region Create
        public async Task<CommandResponse> CreateAsync(CreateLocationRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new CreateLocationRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    //mapping
                    Location mappedItem = _autoMapper.Map<Location>(item);
                    var IsCreated = await _LocationRepository.CreateAsync(mappedItem);
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
        public async Task<GetLocationRequestDto> GetByIdAsync(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    Location item = await _LocationRepository.GetByIdAsync(Id);
                    if (item is not null)
                    {
                        //mapping
                        GetLocationRequestDto mappedItem = _autoMapper.Map<GetLocationRequestDto>(item);

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
