using AutoMapper;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Dtos.PaymentDto;
using SmartBill.BusinessLogicLayer.Services.ApplicationUserServices;
using SmartBill.BusinessLogicLayer.Services.BankAccountServices;
using SmartBill.BusinessLogicLayer.Services.BillServerServices;
using SmartBill.BusinessLogicLayer.Services.BillServices;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.PaymentValidators;
using SmartBill.BusinessLogicLayer.ViewModels.PaymentVM;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.PaymentRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.PaymentServices
{
    public class PaymentService : GenericService<Payment>, IPaymentService
    {
        #region Field and Ctor
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _autoMapper;
        private readonly IBillService _billService;
        private readonly IBillServerService _billServerService;
        private readonly IBankAccountService _bankAccountService;
        private readonly IApplicationUserService _applicationUserService;

        public PaymentService(IPaymentRepository paymentRepository, IMapper autoMapper, IBillService billService, IBankAccountService bankAccountService, IBillServerService billServerService, IApplicationUserService applicationUserService) : base(autoMapper, paymentRepository)
        {
            _paymentRepository = paymentRepository;
            _autoMapper = autoMapper;
            _billService = billService;
            _bankAccountService = bankAccountService;
            _billServerService = billServerService;
            _applicationUserService = applicationUserService;
        }

        #endregion

        #region GetAllPaidAsync
        public async Task<IEnumerable<GetAllPaymentRequestDto>> GetAllPaidAsync()
        {
            try
            {
                IEnumerable<Payment> items = await _paymentRepository.GetAllByAsync(x => x.IsBillPaid == true);

                IEnumerable<GetAllPaymentRequestDto> result = _autoMapper.Map<IEnumerable<Payment>, IEnumerable<GetAllPaymentRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region GetAllUnPaidAsync
        public async Task<IEnumerable<GetAllPaymentRequestDto>> GetAllUnPaidAsync()
        {
            try
            {
                IEnumerable<Payment> items = await _paymentRepository.GetAllByAsync(x => x.IsBillPaid == false);

                IEnumerable<GetAllPaymentRequestDto> result = _autoMapper.Map<IEnumerable<Payment>, IEnumerable<GetAllPaymentRequestDto>>(items);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
        #region Create payment opetaion
        public async Task<CommandResponse> CreateAsync(CreatePaymentRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new CreatePaymentRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    var getBill = await _billService.GetByIdAsync(item.BillId); //check if do we have this bill
                    if (getBill != null)
                    {
                        var getBankAccountOwner = await _bankAccountService.GetByIdAsync(item.BankAccountId); //check if the person who wants to pay has a bank account 
                        if (getBankAccountOwner != null)
                        {
                            if (getBankAccountOwner.Balance >= getBill.BillAmount)
                            {
                                getBankAccountOwner.Balance = getBankAccountOwner.Balance - getBill.BillAmount;
                                getBill.IsBillPaid = true;
                                item.IsBillPaid = true;
                                await _bankAccountService.UpdateAsync(_autoMapper.Map<UpdateBankAccountRequestDto>(getBankAccountOwner)); //update user's balance
                                await _billService.UpdateAsync(_autoMapper.Map<UpdateBillRequestDto>(getBill));//make bill as paid
                            }
                        }
                    }
                    //mapping
                    Payment mappedItem = _autoMapper.Map<Payment>(item);
                    var IsCreated = await _paymentRepository.CreateAsync(mappedItem);
                    if (IsCreated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };

                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        #endregion

        #region GetAllAsync
        public async Task<IEnumerable<GetAllPaymentRequestDto>> GetAllAsync()
        {

            try
            {
                IEnumerable<Payment> items = await _paymentRepository.GetAllByAsync();

                IEnumerable<GetAllPaymentRequestDto> result = _autoMapper.Map<IEnumerable<Payment>, IEnumerable<GetAllPaymentRequestDto>>(items); 

                return result;
            }
            catch (Exception ex) { return null; }
        }
        #endregion

        #region GetPayment
        public async Task<GetPaymentRequestDto> GetByIdAsync(string Id)
        {
            try
            {
                Payment item = await _paymentRepository.GetByIdAsync(Id);
                GetPaymentRequestDto mappedItem = _autoMapper.Map<GetPaymentRequestDto>(item);

                if (item is not null )
                {
                    mappedItem.Bill = _autoMapper.Map<Bill>(await _billService.GetByIdAsync(item.BillId));
                    mappedItem.BillServer = _autoMapper.Map<BillServer>(await _billServerService.GetByIdAsync(mappedItem.Bill.BillServerId));
                    mappedItem.BankAccount = _autoMapper.Map<BankAccount>(await _bankAccountService.GetByIdAsync(mappedItem.BankAccountId));
                    mappedItem.ApplicationUser = _autoMapper.Map<ApplicationUser>(await _applicationUserService.GetByIdAsync(mappedItem.Bill.ApplicationUserId));

                    //mapping

                    return mappedItem;
                }
                return null;

            }
            catch (Exception ex) { return null; }
        }
        #endregion


        /*#region GetApplicationUserByEmail
        public async Task<ListPaymentByCustomerVM> GetApplicationUserByEmailAsync(string email)
        {
            try
            {
                var user = await _applicationUserService.GetListPaymentByEmailAsync(email);
                if (user == null)
                    return null;
                return user;
            }
            catch (Exception ex) { return null; }
        }
        #endregion


        #region GetPaymentByCustomer
        public async Task<IEnumerable<GetAllPaymentRequestDto>> GetAllPaymentByCustomerAsync(string Id)
        {
            try
            {
                IEnumerable<Payment> items = await _paymentRepository.GetAllByAsync(x => x.ApplicationUserId == Id);

                IEnumerable<GetAllPaymentRequestDto> result = _autoMapper.Map<IEnumerable<Payment>, IEnumerable<GetAllPaymentRequestDto>>(items);

                return result;
            }
            catch (Exception ex) { return null; }
        }
        #endregion
        */
    }
}
