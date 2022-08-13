using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Services.AppartmentServices;
using SmartBill.BusinessLogicLayer.Services.ApplicationUserServices;
using SmartBill.BusinessLogicLayer.Services.BillServerServices;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.BillValidators;
using SmartBill.BusinessLogicLayer.ViewModels.ApplicationUserVM;
using SmartBill.BusinessLogicLayer.ViewModels.BillVM;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.BillRepositories;
using SmartBill.Entities.Domains;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.BillServices
{
    public class BillService : GenericService<Bill>, IBillService
    {
        #region Field and Ctor
        private readonly IBillRepository _billRepository;
        private readonly IBillServerService _billServerService;
        private readonly IApartmentService _apartmentService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _autoMapper;

        public BillService(IMapper autoMapper, IBillRepository billRepository, IBillServerService billServerService, IApartmentService apartmentService, IApplicationUserService applicationUserService) : base(autoMapper, billRepository)
        {
            _autoMapper = autoMapper;
            _billRepository = billRepository;
            _apartmentService = apartmentService;
            _billServerService = billServerService;
            _applicationUserService = applicationUserService;
        }

        #endregion

        #region make it paid
        public async Task<CommandResponse> ActivateAsync(string Id)
        {
            try
            {
                Bill item = await _billRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsBillPaid = true;
                item.ActivatedDate = DateTime.Now;
                bool IsUpdated = await _billRepository.UpdateAsync(item);
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
                Bill item = await _billRepository.GetByIdAsync(Id);
                if (item == null)
                    return null;
                item.IsBillPaid = false;
                item.UnActivatedDate = DateTime.Now;
                bool IsUpdated = await _billRepository.UpdateAsync(item);
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
        public async Task<IEnumerable<GetAllBillRequestDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<Bill> items = await _billRepository.GetAllByAsync();
                IEnumerable<GetAllBillRequestDto> result = _autoMapper.Map<IEnumerable<Bill>, IEnumerable<GetAllBillRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion


        #region GetAllActivated
        public async Task<IEnumerable<GetAllBillRequestDto>> GetAllActivatedAsync()
        {
            try
            {
                IEnumerable<Bill> items = await _billRepository.GetAllByAsync(x => x.IsBillPaid == true);

                IEnumerable<GetAllBillRequestDto> result = _autoMapper.Map<IEnumerable<Bill>, IEnumerable<GetAllBillRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllBillRequestDto>> GetAllUnActivatedAsync()
        {
            try
            {
                IEnumerable<Bill> items = await _billRepository.GetAllByAsync(x => x.IsBillPaid == false);

                IEnumerable<GetAllBillRequestDto> result = _autoMapper.Map<IEnumerable<Bill>, IEnumerable<GetAllBillRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        #endregion


        #region Update

        public async Task<CommandResponse> UpdateAsync(UpdateBillRequestDto item)
        {
            try
            {
                var getItem = await _billRepository.GetByIdAsync(item.Id);
                if (item is not null && getItem is not null)
                {
                    //validation
                    var validator = new UpdateBillRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //mapping
                    Bill mappedItem = _autoMapper.Map<Bill>(item);
                    if (item.IsBillPaid == false && getItem.IsBillPaid == true)
                    {
                        mappedItem.UnActivatedDate = DateTime.Now;
                        mappedItem.ActivatedDate = null;
                    }
                    else if (item.IsBillPaid == true && getItem.IsBillPaid == false)
                    {
                        mappedItem.ActivatedDate = DateTime.Now;
                        mappedItem.UnActivatedDate = null;
                    }


                    bool IsUpdated = await _billRepository.UpdateAsync(mappedItem);
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
        public async Task<CommandResponse> CreateAsync(CreateBillRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new CreateBillRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    //mapping
                    Bill mappedItem = _autoMapper.Map<Bill>(item);
                    var IsCreated = await _billRepository.CreateAsync(mappedItem);
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
        public async Task<GetBillRequestDto> GetByIdAsync(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    Bill item = await _billRepository.GetByIdAsync(Id);
                    if (item is not null)
                    {
                        //mapping
                        GetBillRequestDto mappedItem = _autoMapper.Map<GetBillRequestDto>(item);

                        mappedItem.BillServer = _autoMapper.Map<BillServer>(await _billServerService.GetByIdAsync(item.BillServerId));

                        mappedItem.Apartment = _autoMapper.Map<Apartment>(await _apartmentService.GetByIdAsync(item.ApartmentId));
                        mappedItem.ApplicationUser = _autoMapper.Map<ApplicationUser>(await _applicationUserService.GetByIdAsync(item.ApplicationUserId));
                        return mappedItem;
                    }
                    return null;
                }

                { return null; }

            }
            catch (Exception ex) { return null; }
        }


        #endregion

        #region Get aparts and billTypes
        public async Task<IEnumerable<ApartmentBillListVM>> GetActivatedApartments()
        {
            try
            {
                var items = await _apartmentService.GetAllActivatedAsync();
                IEnumerable<ApartmentBillListVM> vm = items.Select(d => new ApartmentBillListVM { Id = d.Id, Name = d.Name });
                if (vm.Any())
                    return vm;
                return null;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<IEnumerable<BillServerBillListVM>> GetActivatedBillServers()
        {
            try
            {
                var items = await _billServerService.GetAllActivatedAsync();
                IEnumerable<BillServerBillListVM> vm = items.Select(d => new BillServerBillListVM { Id = d.Id, Name = d.Name });
                if (vm.Any())
                    return vm;
                return null;
            }
            catch (Exception ex) { return null; }
        }

        public async Task<IEnumerable<ApplicationUserBillListVM>> GetActivatedApplicationUsers()
        {
            try
            {
                var items = await _applicationUserService.GetAllActivatedAsync();
                IEnumerable<ApplicationUserBillListVM> vm = items.Select(d => new ApplicationUserBillListVM { Id = d.Id, Name = d.FirstName +" "+ d.LastName + " "+ d.TurkishIdentity });
                if (vm.Any())
                    return vm;
                return null;
            }
            catch (Exception ex) { return null; }
        }

        #endregion
    }


}

