using Microsoft.AspNetCore.Mvc;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Services.AppartmentServices;
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

        public IActionResult Index()
        {
            try
            {
                return View();

            }catch(Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> GetAllActivated()
        {
            try
            {
                var result = await _apartmentService.GetAllActivated();
                return View(result);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> GetAllUnActivated()
        {
            try
            {
                var result = await _apartmentService.GetAllUnActivated();
                return View(result);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }


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
        public async Task<IActionResult> Create(CreateApartmentRequestDto model)
        {
            try
            {
                var result = await _apartmentService.Create(model);
                return View(result);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
