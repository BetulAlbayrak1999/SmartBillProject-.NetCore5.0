using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.BillServerValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.BillServerRepositories;
using SmartBill.Entities.Domains;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BillServerServices
{
    public class BillServerService : GenericService<BillServer>, IBillServerService
    {
        #region Field and Ctor
        private readonly IBillServerRepository _BillServerRepository;
        private readonly IMapper _autoMapper;
        public BillServerService(IMapper autoMapper, IBillServerRepository BillServerRepository) : base(autoMapper, BillServerRepository)
        {
            _autoMapper = autoMapper;
            _BillServerRepository = BillServerRepository;
        }

        #endregion

        #region Activate
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                BillServer item = await _BillServerRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = true;
                item.ActivatedDate = DateTime.Now;
                bool IsUpdated = await _BillServerRepository.UpdateAsync(item);
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
                BillServer item = await _BillServerRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsActive = false;
                item.UnActivatedDate = DateTime.Now;
                bool IsUpdated = await _BillServerRepository.UpdateAsync(item);
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
        public async Task<IEnumerable<GetAllBillServerRequestDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<BillServer> items = await _BillServerRepository.GetAllByAsync();
                IEnumerable<GetAllBillServerRequestDto> result = _autoMapper.Map<IEnumerable<BillServer>, IEnumerable<GetAllBillServerRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region GetAllActivated
        public async Task<IEnumerable<GetAllBillServerRequestDto>> GetAllActivatedAsync()
        {
            try
            {
                IEnumerable<BillServer> items = await _BillServerRepository.GetAllByAsync(x => x.IsActive == true);

                IEnumerable<GetAllBillServerRequestDto> result = _autoMapper.Map<IEnumerable<BillServer>, IEnumerable<GetAllBillServerRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllBillServerRequestDto>> GetAllUnActivatedAsync()
        {
            try
            {
                IEnumerable<BillServer> items = await _BillServerRepository.GetAllByAsync(x => x.IsActive == false);

                IEnumerable<GetAllBillServerRequestDto> result = _autoMapper.Map<IEnumerable<BillServer>, IEnumerable<GetAllBillServerRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion


        #region Update

        public async Task<CommandResponse> UpdateAsync(UpdateBillServerRequestDto item)
        {
            try
            {
                var getItem = await _BillServerRepository.GetByIdAsync(item.Id);
                if (item is not null && getItem is not null)
                {
                    //validation
                    var validator = new UpdateBillServerRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //set last modify time
                    //mapping
                    BillServer mappedItem = _autoMapper.Map<BillServer>(item);
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


                    bool IsUpdated = await _BillServerRepository.UpdateAsync(mappedItem);
                    if (IsUpdated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        #endregion


        #region Create
        public async Task<CommandResponse> CreateAsync(CreateBillServerRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new CreateBillServerRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    //mapping
                    BillServer mappedItem = _autoMapper.Map<BillServer>(item);
                    var IsCreated = await _BillServerRepository.CreateAsync(mappedItem);
                    if (IsCreated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        #endregion

        #region GetByIdAsync
        public async Task<GetBillServerRequestDto> GetByIdAsync(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    BillServer item = await _BillServerRepository.GetByIdAsync(Id);
                    if (item is not null)
                    {
                        //mapping
                        GetBillServerRequestDto mappedItem = _autoMapper.Map<GetBillServerRequestDto>(item);

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

