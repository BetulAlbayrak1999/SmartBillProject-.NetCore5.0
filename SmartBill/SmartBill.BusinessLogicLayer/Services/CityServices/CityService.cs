using AutoMapper;
using SmartBill.BusinessLogicLayer.Dtos.CityDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.CityValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.CityRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CityServices
{
    /// <summary>
    /// /////////TAKE A LOOK AGAİN
    /// </summary>
    public class CityService : ICityService
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _autoMapper;
        public CityService(IMapper autoMapper, ICityRepository CityRepository) 
        {
            _autoMapper = autoMapper;
            _CityRepository = CityRepository;
        }

        public Task<IEnumerable<GetAllCityRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllCityRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateCityRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
