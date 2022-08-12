using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using SmartBill.BusinessLogicLayer.Services.ApplicationUserServices;
using SmartBill.BusinessLogicLayer.Services.BankAccountServices;
using SmartBill.BusinessLogicLayer.ViewModels.BankAccountVM;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    public class BankAccountsController : Controller
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly ILogger<BankAccountsController> logger;
        public BankAccountsController(IBankAccountService bankAccountService, ILogger<BankAccountsController> logger)
        {
            _bankAccountService = bankAccountService;
            this.logger = logger;
        }

        #region Index
        public IActionResult Index()
        {
            try
            {
                return View();

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion


        #region GetAllActivated
        public async Task<IActionResult> GetAllActivated()
        {
            try
            {
                var result = await _bankAccountService.GetAllActivatedAsync();
                return View(result);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region GetAll
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _bankAccountService.GetAllAsync();
                if (result is not null)
                    return View(result);
                return null;

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region GetAllUnActivated
        public async Task<IActionResult> GetAllUnActivated()
        {
            try
            {
                var result = await _bankAccountService.GetAllUnActivatedAsync();
                return View(result);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region Delete

        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                var result = await _bankAccountService.DeleteAsync(Id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        #endregion


        #region Create
        public IActionResult Create()
        {
            try
            {
                
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBankAccountRequestDto model)
        {
            try
            {
                var result = await _bankAccountService.CreateAsync(model);
                if(result is not null)
                    return RedirectToAction("GetAll");
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(string Id)
        {
            try
            {
                var result = await _bankAccountService.GetByIdAsync(Id);
                if (result == null)
                    return NotFound();
                var viewModel = new UpdateBankAccountRequestDto
                {
                    Id = result.Id,
                    BankName = result.BankName,
                    Balance = result.Balance,
                    IsActive = result.IsActive
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateBankAccountRequestDto model)
        {
            try
            {
                var result = await _bankAccountService.UpdateAsync(model);
                if (result.Status == false)
                    return BadRequest();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region GetById
        public async Task<IActionResult> GetById(string Id)
        {
            try
            {
                var result = await _bankAccountService.GetByIdAsync(Id);
                if (result == null)
                    return NotFound();
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region Activate
        public async Task<IActionResult> Activate(string Id)
        {
            try
            {
                var result = await _bankAccountService.ActivateAsync(Id);
                if (result == null)
                    return NotFound();
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region UnActivate
        public async Task<IActionResult> UnActivate(string Id)
        {
            try
            {
                var result = await _bankAccountService.UnActivateAsync(Id);
                if (result == null)
                    return NotFound();
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion
    }
}
