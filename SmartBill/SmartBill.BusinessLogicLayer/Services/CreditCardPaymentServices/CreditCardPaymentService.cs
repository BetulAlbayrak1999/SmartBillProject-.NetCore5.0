using AutoMapper;
using MongoDB.Bson;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Dtos.CreditCardPaymentDto;
using SmartBill.BusinessLogicLayer.Services.ApplicationUserServices;
using SmartBill.BusinessLogicLayer.Services.BankAccountServices;
using SmartBill.BusinessLogicLayer.Services.BillServerServices;
using SmartBill.BusinessLogicLayer.Services.BillServices;
using SmartBill.BusinessLogicLayer.Validators.CreditCardPaymentValidators;
using SmartBill.DataAccessLayer.Repositories.MongoDBRepositories.CreditCardPaymentRepositories;
using SmartBill.Entities.Domains.MongoDB;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartBill.BusinessLogicLayer.Services.CreditCardPaymentServices
{
    public class CreditCardPaymentService : ICreditCardPaymentService
    {
        #region dependencyInjec
        private readonly ICreditCardPaymentRepository _repository;
        private readonly IMapper _autoMapper;
        private readonly IBillService _billService;
        private readonly IBillServerService _billServerService;
        private readonly IBankAccountService _bankAccountService;
        private readonly IApplicationUserService _applicationUserService;
        
        public CreditCardPaymentService(ICreditCardPaymentRepository repository, IMapper autoMapper, IBillService billService, IBankAccountService bankAccountService, IBillServerService billServerService, IApplicationUserService applicationUserService)
        {
            _repository = repository;
            _autoMapper = autoMapper;
            _billService = billService;
            _bankAccountService = bankAccountService;
            _billServerService = billServerService;
            _applicationUserService = applicationUserService;
        }
        #endregion

        #region Create payment opetaion
        public async Task<CommandResponse> CreateCreditCardPayment(CreateCreditCardPaymentRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new CreateCreditCardPaymentRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    var getBill = await _billService.GetByIdAsync(item.BillId); //check if do we have this bill
                    if (getBill != null)
                    {
                        var getBankAccountOwner = await _bankAccountService.GetByIdAsync(item.BankAccountId); //check if the person who wants to pay has a bank account 
                        if(getBankAccountOwner != null)
                        {
                            if(getBankAccountOwner.Balance >= getBill.BillAmount)
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
                    CreditCardPayment mappedItem = _autoMapper.Map<CreditCardPayment>(item);
                     _repository.Create(mappedItem);
                    }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }

        }
        #endregion

        #region GetAllCreditCardPayment
        public IEnumerable<GetAllCreditCardPaymentRequestDto> GetAllCreditCardPayment()
        {

            try
            {
                IEnumerable<CreditCardPayment> items = _repository.GetAll();

                IEnumerable<GetAllCreditCardPaymentRequestDto> result = _autoMapper.Map<IEnumerable<CreditCardPayment>, IEnumerable<GetAllCreditCardPaymentRequestDto>>(items);

                return result;
            }
            catch (Exception ex) { return null; }
        }
        #endregion

        #region GetCreditCardPayment
        public async Task<GetCreditCardPaymentRequestDto> GetCreditCardPayment(ObjectId Id)
        {
            try
            {
                CreditCardPayment item =  _repository.Get(Id);
                GetCreditCardPaymentRequestDto mappedItem = _autoMapper.Map<GetCreditCardPaymentRequestDto>(item);

                if (item is not null && item.IsBillPaid == true)
                {
                    mappedItem.Bill = _autoMapper.Map<Bill>(await _billService.GetByIdAsync(item.BillId));
                    mappedItem.BillServer = _autoMapper.Map<BillServer>(await _billServerService.GetByIdAsync(mappedItem.Bill.BillServerId));
                    mappedItem.BankAccount = _autoMapper.Map<BankAccount>(await _bankAccountService.GetByIdAsync(mappedItem.BankAccountId));
                    mappedItem.ApplicationUser = _autoMapper.Map<ApplicationUser>(await  _applicationUserService.GetByIdAsync(mappedItem.BankAccount.ApplicationUserId));

                    //mapping

                    return mappedItem;
                }
                return null;
                
            }
            catch (Exception ex) { return null; }
        }
        #endregion

        #region UpdateCreditCardPayment
        public CommandResponse UpdateCreditCardPayment(UpdateCreditCardPaymentRequestDto item)
        {
            try
            {
                var getItem =  _repository.Get(item.Id);
                if (item is not null && getItem is not null) //=> this item exists in db
                {
                    //validation
                    var validator = new UpdateCreditCardPaymentRequestValidator();
                    validator.Validate(item).throwIfValidationException();

                    //mapping
                    CreditCardPayment model =  _autoMapper.Map<CreditCardPayment>(item);
                     _repository.Update(model);
                    { return new CommandResponse { Status = true, Message = "This operation has done successfully" }; }
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }

        }
        #endregion
    }
}
