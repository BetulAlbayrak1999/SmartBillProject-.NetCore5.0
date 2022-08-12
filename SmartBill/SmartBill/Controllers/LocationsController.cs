using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Services.LocationServices;
using System;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ILogger<LocationsController> _logger;
        public LocationsController(ILocationService locationService, ILogger<LocationsController> logger)
        {
            _locationService = locationService;
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
                var result = await _locationService.GetAllActivatedAsync();
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
                var result = await _locationService.GetAllAsync();
                if(result is not null)
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
                var result = await _locationService.GetAllUnActivatedAsync();
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
                var result = await _locationService.DeleteAsync(Id);
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
        public async Task<IActionResult> Create(CreateLocationRequestDto model)
        {
            try
            {
                var result = await _locationService.CreateAsync(model);
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
                var result = await _locationService.GetByIdAsync(Id);
                if (result == null)
                    return NotFound();
                var viewModel = new UpdateLocationRequestDto
                {
                    Id = result.Id,
                    City = result.City,
                    Region = result.Region,
                    PostalCode = result.PostalCode,
                    Street = result.Street,
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
        public async Task<IActionResult> Update(UpdateLocationRequestDto model)
        {
            try
            {
                var result = await _locationService.UpdateAsync(model);
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
                var result = await _locationService.GetByIdAsync(Id);
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
                var result = await _locationService.ActivateAsync(Id);
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
                var result = await _locationService.UnActivateAsync(Id);
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

