using Moq;
using SmartBill.BusinessLogicLayer.Configrations.Helpers;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Services.BillServices;
using SmartBill.BusinessLogicLayer.Services.LocationServices;
using SmartBill.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartBill.Test.BillTest
{
    public class CalculateTaxTest
    {
        private readonly Mock<ILocationService> _mockbillService;

        public CalculateTaxTest(Mock<ILocationService> mockbillService)
        {
            _mockbillService = mockbillService;
        }

        [Fact]
        public async void CalculateTax_Success()
        {
            CreateLocationRequestDto dto = new CreateLocationRequestDto();
            dto.Street = "css";
            dto.City = "css";
            dto.Region = "hirka";
            dto.PostalCode = "12345";

            _mockbillService.Setup(p => p.CreateAsync(dto)).ReturnsAsync("JK");
            LocationsController emp = new EmployeeController(mock.Object);
            string result = await emp.GetEmployeeById(1);
            Assert.Equal("JK", result);

            // arrange-- kullanılacak olan parametre ve servislerin hazırlanmasıdır
            float price = 100;

            //act
            var response = _mockbillService.Object.CalculateTax(price);

            //assert
            Assert.Equal(response, (float)18);

        }
    }
}