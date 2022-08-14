using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Services.LocationServices;
using SmartBill.Controllers;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.LocationRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartBill.Test.LocationTests
{
    public class LocationTest
    {
        private readonly Mock<ILocationService> _mockLocationService;
        private readonly ILogger<LocationsController> _logger;
        public LocationTest(Mock<ILocationService> mockLocationService, ILogger<LocationsController> logger)
        {
            _mockLocationService = mockLocationService;
            _logger = logger;
        }

        [Fact]
        public async Task GetById()
        {
            //arrange
            
            GetLocationRequestDto item = new GetLocationRequestDto
            {
                Id = "73f994ac-3ee5-425c-9b29-80163a7dc10e",
                IsActive = false,
                City = "istanbul",
                Region = "fatih",
                Street = "Hirka-i serif, Armutlu Sk.",
                PostalCode = "12342",
                CreatedDate = Convert.ToDateTime("2022-08-10 10:46:09.2622128"),
                LastModifiedDate = Convert.ToDateTime("2022-08-10 10:46:09.2622243"),
                ActivatedDate = null,
                UnActivatedDate = null
            };
             _mockLocationService.Setup(p => p.GetByIdAsync("73f994ac-3ee5-425c-9b29-80163a7dc10e")).ReturnsAsync(item);

            //act 
            LocationsController controller = new LocationsController(_mockLocationService.Object, _logger);

            var result = await controller.GetById("73f994ac-3ee5-425c-9b29-80163a7dc10e");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<GetLocationRequestDto>(viewResult.ViewData.Model);
            Assert.Equal(item, model);
        }

    }
}



