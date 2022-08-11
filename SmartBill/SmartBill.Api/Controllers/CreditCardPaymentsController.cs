using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SmartBill.BusinessLogicLayer.Dtos.CreditCardPaymentDto;
using SmartBill.BusinessLogicLayer.Services.CreditCardPaymentServices;
using SmartBill.Entities.Domains.MongoDB;
using System;
using System.Threading.Tasks;

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
            try {
                var data = _service.GetAllCreditCardPayment();
                return Ok(data);
            }
            catch (Exception ex) { return null; }
            
        }

        [HttpGet("GetById")]
        public async Task<GetCreditCardPaymentRequestDto> GetById(string id)
        {
            try {
                return await _service.GetCreditCardPayment(new ObjectId(id));
            }catch(Exception ex) { return null; }
            
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateCreditCardPaymentRequestDto request)
        {
            try {
                await _service.CreateCreditCardPayment(request);
                return Ok();
            }
            catch (Exception ex) { return null; }
            
        }

        [HttpPut]
        public IActionResult Put(UpdateCreditCardPaymentRequestDto request)
        {
            try {
                _service.UpdateCreditCardPayment(request);
                return Ok();
            }
            catch (Exception ex) { return null; }
            
        }

    }
}
