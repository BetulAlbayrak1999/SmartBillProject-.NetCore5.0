using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> GetAllActive()
        {
            try
            {
                var result = await _apartmentService.GetAllActive();
                return View(result);

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
