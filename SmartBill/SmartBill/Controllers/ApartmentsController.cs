using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Services.AppartmentServices;
using SmartBill.DataAccessLayer.Data;
using System;
using System.Threading.Tasks;

namespace SmartBill.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
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
                var result = await _apartmentService.GetAllActivatedAsync();
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
                var result = await _apartmentService.GetAllAsync();
                return View(result);

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
                var result = await _apartmentService.GetAllUnActivatedAsync();
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
                var result = await _apartmentService.DeleteAsync(Id);
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
                /*var ApplicationUserRepository = new ApplicationUserRepository();
                var users =await _context.Users.ToListAsync();
                ViewBag.ApplicationUsers = users;

                var locations = await _context.Locations.ToListAsync();
                ViewBag.Locations = locations;*/

                return View();

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateApartmentRequestDto model)
        {
            try
            {
                var result = await _apartmentService.CreateAsync(model);
                return RedirectToAction("GetAll");

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        #endregion

        #region Update
        public async Task <IActionResult> Update(string Id)
        {
            try
            {
                var result = await _apartmentService.GetByIdAsync(Id);
                if (result == null)
                    return NotFound();
                var viewModel = new UpdateApartmentRequestDto
                {
                    Id = result.Id,
                    PersonsNumber = result.PersonsNumber,
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
        public async Task<IActionResult> Update(UpdateApartmentRequestDto model)
        {
            try
            {
                var result = await _apartmentService.UpdateAsync(model);
                if(result.Status == false)
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
                var result = await _apartmentService.GetByIdAsync(Id);
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
                var result = await _apartmentService.ActivateAsync(Id);
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
                var result = await _apartmentService.UnActivateAsync(Id);
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
