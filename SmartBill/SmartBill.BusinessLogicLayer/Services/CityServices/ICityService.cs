using SmartBill.BusinessLogicLayer.Dtos.CityDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.CityValidators;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CityServices
{
    public interface ICityService //: IGenericService<CreateCityRequestDto, CreateCityRequestValidator, GetCityRequestDto, City>
    {
        public Task<IEnumerable<GetAllCityRequestDto>> GetAllActivated();

        public Task<IEnumerable<GetAllCityRequestDto>> GetAllUnActivated();

        public Task<bool> Update(UpdateCityRequestDto item);

    }
}
