using Microsoft.AspNetCore.Mvc;

namespace SmartBill.Controllers
{
    public class ApartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
