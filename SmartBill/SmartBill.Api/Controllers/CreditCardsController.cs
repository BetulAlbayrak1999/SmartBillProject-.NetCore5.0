using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SmartBill.BusinessLogicLayer.Services.CreditCardServices;
using SmartBill.Entities.Domains.MongoDB;

namespace SmartBill.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly ICreditCardService _service;

        public CreditCardsController(ICreditCardService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var data = _service.GetAllCreditCard();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public CreditCardPayment GetById(string id)
        {

            return _service.GetCreditCard(new ObjectId(id));
        }


        [HttpPost]
        public IActionResult Post(CreditCardPayment request)
        {
            _service.CreateCreditCard(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(CreditCardPayment request)
        {
            _service.UpdateCreditCard(request);
            return Ok();
        }

    }
}
