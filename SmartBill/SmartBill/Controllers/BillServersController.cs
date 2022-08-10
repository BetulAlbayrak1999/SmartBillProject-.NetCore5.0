using Microsoft.AspNetCore.Mvc;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using SmartBill.BusinessLogicLayer.Services.BillServerServices;
using System;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    public class BillServersController : Controller
    {
        private readonly IBillServerService _billServerService;

        public BillServersController(IBillServerService billServerService)
        {
            _billServerService = billServerService;
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
                var result = await _billServerService.GetAllActivatedAsync();
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
                var result = await _billServerService.GetAllAsync();
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
                var result = await _billServerService.GetAllUnActivatedAsync();
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
                var result = await _billServerService.DeleteAsync(Id);
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
        public async Task<IActionResult> Create(CreateBillServerRequestDto model)
        {
            try
            {
                var result = await _billServerService.CreateAsync(model);
                return RedirectToAction("GetAll");

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
                var result = await _billServerService.GetByIdAsync(Id);
                if (result == null)
                    return NotFound();
                var viewModel = new UpdateBillServerRequestDto
                {
                    Id = result.Id,
                   Name = result.Name,
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
        public async Task<IActionResult> Update(UpdateBillServerRequestDto model)
        {
            try
            {
                var result = await _billServerService.UpdateAsync(model);
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
                var result = await _billServerService.GetByIdAsync(Id);
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
                var result = await _billServerService.ActivateAsync(Id);
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
                var result = await _billServerService.UnActivateAsync(Id);
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

