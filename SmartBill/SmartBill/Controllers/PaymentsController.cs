using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBill.BusinessLogicLayer.Dtos.PaymentDto;
using SmartBill.BusinessLogicLayer.Services.PaymentServices;
using System;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentsController> _logger;
        public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
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


        #region GetAllPaid
        public async Task<IActionResult> GetAllPaid()
        {
            try
            {
                var result = await _paymentService.GetAllPaidAsync();
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
                var result = await _paymentService.GetAllAsync();
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

        #region GetAllUnPaid
        public async Task<IActionResult> GetAllUnPaid()
        {
            try
            {
                var result = await _paymentService.GetAllUnPaidAsync();
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
                var result = await _paymentService.DeleteAsync(Id);
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
        public async Task<IActionResult> Create(CreatePaymentRequestDto model)
        {
            try
            {
                var result = await _paymentService.CreateAsync(model);
                return RedirectToAction("GetAll");

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
                var result = await _paymentService.GetByIdAsync(Id);
                if (result == null)
                    return View();
                return View(result);
            }
            catch (Exception ex)
            {
                ViewBag.ex = ex.Message;
                return View(model);
            }
        }
        #endregion
    }
}
