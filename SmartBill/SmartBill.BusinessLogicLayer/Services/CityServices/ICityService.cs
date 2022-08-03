using SmartBill.BusinessLogicLayer.Dtos.CityDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CityServices
{
    public interface ICityService : IGenericService<CreateCityRequestDto, UpdateCityRequestDto, GetAllCityRequestDto, GetCityRequestDto>
    {
    }
}
