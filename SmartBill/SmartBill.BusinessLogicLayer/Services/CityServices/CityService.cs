using AutoMapper;
using SmartBill.BusinessLogicLayer.Dtos.CityDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.CityValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.CityRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.CityServices
{
    public class CityService// : GenericService<CreateCityRequestDto, CreateCityRequestValidator, GetCityRequestDto, City>, ICityService
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMapper _autoMapper;
       /* public CityService(IMapper autoMapper, ICityRepository CityRepository) : base(autoMapper, CityRepository)
        {
            _autoMapper = autoMapper;
            _CityRepository = CityRepository;
        }*/

        #region GetAllActivated
        public async Task<IEnumerable<GetAllCityRequestDto>> GetAllActivated()
        {
            try
            {
                IEnumerable<City> items = await _CityRepository.GetAllAsync();

                IEnumerable<GetAllCityRequestDto> result = items.Where(d => d.IsActive == true).Select(d => new GetAllCityRequestDto
                {
                    //id

                });
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion


        #region GetAllUnActivated

        public async Task<IEnumerable<GetAllCityRequestDto>> GetAllUnActivated()
        {
            try
            {
                IEnumerable<City> items = await _CityRepository.GetAllAsync();

                IEnumerable<GetAllCityRequestDto> result = items.Where(d => d.IsActive == false).Select(d => new GetAllCityRequestDto
                {
                    

                });
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion


        #region Update

        /*public async Task<bool> Update(UpdateCityRequestDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new UpdateCityRequestValidator();
                    validator.Validate(item).throwIfValidationException();
                    //set last modify time
                    //mapping
                    City mappedItem = _autoMapper.Map<City>(item);
                    if (item.IsActive == false)
                    {
                        mappedItem.UnActivedDate = DateTime.Now;
                        mappedItem.ActivedDate = null;
                    }
                    else if (item.IsActive == true)
                    {
                        mappedItem.ActivedDate = DateTime.Now;
                        mappedItem.UnActivedDate = null;
                    }
                    if (item.PersonsNumber == 0)
                        item.IsEmpty = true;
                    else { item.IsEmpty = false; }

                    bool IsUpdated = await _CityRepository.Update(mappedItem);
                    if (IsUpdated == true)
                        return true;

                    return false;
                }

                { return false; }

            }
            catch (Exception ex) { return false; }

        }*/


        #endregion
    }
}
