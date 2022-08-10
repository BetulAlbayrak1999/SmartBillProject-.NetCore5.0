using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SmartBill.BusinessLogicLayer.Services.CreditCardServices;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardPaymentsController : ControllerBase
    {
        private readonly ICreditCardPaymentService _service;

        public CreditCardPaymentsController(ICreditCardPaymentService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _service.GetAllCreditCardPayment();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public CreditCardPayment GetById(string id)
        {

            return _service.GetCreditCardPayment(new ObjectId(id));
        }


        [HttpPost]
        public IActionResult Post(CreditCardPayment request)
        {
            _service.CreateCreditCardPayment(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(CreditCardPayment request)
        {
            _service.UpdateCreditCardPayment(request);
            return Ok();
        }

    }
}
