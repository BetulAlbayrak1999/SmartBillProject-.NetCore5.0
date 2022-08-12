using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Services.BillServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SmartBill.Controllers
{
    public class BillsController : Controller
    {
        private readonly IBillService _billService;
        private readonly ILogger<BillsController> _logger;
        public BillsController(IBillService billService, ILogger<BillsController> logger)
        {
            _billService = billService;
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


        #region GetAllActivated
        public async Task<IActionResult> GetAllActivated()
        {
            try
            {
                var result = await _billService.GetAllActivatedAsync();
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
                var result = await _billService.GetAllAsync();
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
                var result = await _billService.GetAllUnActivatedAsync();
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
                var result = await _billService.DeleteAsync(Id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        #endregion


        #region Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var apartDB = await _billService.GetActivatedApartments();
                if (apartDB == null)
                    return View("Index");
                List<SelectListItem> aparts = (from x in apartDB
                                                   select new SelectListItem
                                                    {
                                                           Text = x.Name,
                                                           Value = x.Id.ToString()
                                                    }).ToList();
                ViewBag.aparts = aparts;

                var billTypeDB = await _billService.GetActivatedBillServers();
                if (billTypeDB == null)
                    return View("Index");
                List<SelectListItem> billTypes = (from x in billTypeDB
                                                      select new SelectListItem
                                                   {
                                                       Text = x.Name,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
                ViewBag.billTypes = billTypes;
               
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBillRequestDto model)
        {
            try
            {
                var result = await _billService.CreateAsync(model);
                if (result is not null)
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
                #region get apart and billServer type 
                var apartDB = await _billService.GetActivatedApartments();
                if (apartDB == null)
                    return View("Index");
                List<SelectListItem> aparts = (from x in apartDB
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Id.ToString()
                                               }).ToList();
                ViewBag.aparts = aparts;

                var billTypeDB = await _billService.GetActivatedBillServers();
                if (billTypeDB == null)
                    return View("Index");
                List<SelectListItem> billTypes = (from x in billTypeDB
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.Id.ToString()
                                                  }).ToList();
                ViewBag.billTypes = billTypes;

                #endregion

                var result = await _billService.GetByIdAsync(Id);
                if (result == null)
                    return NotFound();
                var viewModel = new UpdateBillRequestDto
                {
                    Id = result.Id,
                    BillServerId = result.BillServerId,
                    BillServer = result.BillServer,
                    ApartmentId = result.ApartmentId,
                    Apartment = result.Apartment,
                    BillAmount = result.BillAmount,
                    IsBillPaid = result.IsBillPaid,
                };
   
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateBillRequestDto model)
        {
            try
            {
                var result = await _billService.UpdateAsync(model);
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
                var result = await _billService.GetByIdAsync(Id);
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
                var result = await _billService.ActivateAsync(Id);
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
                var result = await _billService.UnActivateAsync(Id);
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
