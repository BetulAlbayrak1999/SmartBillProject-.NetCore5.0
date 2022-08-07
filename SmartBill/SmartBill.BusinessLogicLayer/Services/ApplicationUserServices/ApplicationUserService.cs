using AutoMapper;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.BusinessLogicLayer.Validators.ApplicationUserValidators;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.ApplicationUserRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.ApplicationUserServices
{
    public class ApplicationUserService : GenericService<CreateApplicationUserRequestDto, CreateApplicationUserRequestValidator, GetApplicationUserRequestDto, GetAllApplicationUserRequestDto, ApplicationUser>, IApplicationUserService
    {
        private readonly IApplicationUserRepository _ApplicationUserRepository;
        private readonly IMapper _autoMapper;
        public ApplicationUserService(IMapper autoMapper, IApplicationUserRepository ApplicationUserRepository) : base(autoMapper, ApplicationUserRepository)
        {
            _autoMapper = autoMapper;
            _ApplicationUserRepository = ApplicationUserRepository;
        }

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateApplicationUserRequestDto item)
        {
            throw new NotImplementedException();
        }
        /*
#region GetAllActivated
public async Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllActivated()
{
   try
   {
       IEnumerable<ApplicationUser> items = await _ApplicationUserRepository.GetAll();

       IEnumerable<GetAllApplicationUserRequestDto> result = items.Where(d => d.IsActive == true).Select(d => new GetAllApplicationUserRequestDto
       {
           Id = d.Id,
           Name = d.Name,
           IsEmpty = d.IsEmpty,
           PersonsNumber = d.PersonsNumber,
           FloorNo = d.FloorNo,
           BlockNo = d.BlockNo,
           ApplicationUserNo = d.ApplicationUserNo,
           LocationId = d.LocationId,
           IsActive = d.IsActive

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

public async Task<IEnumerable<GetAllApplicationUserRequestDto>> GetAllUnActivated()
{
   try
   {
       IEnumerable<ApplicationUser> items = await _ApplicationUserRepository.GetAll();

       IEnumerable<GetAllApplicationUserRequestDto> result = items.Where(d => d.IsActive == false).Select(d => new GetAllApplicationUserRequestDto
       {
           Id = d.Id,
           Name = d.Name,
           IsEmpty = d.IsEmpty,
           PersonsNumber = d.PersonsNumber,
           FloorNo = d.FloorNo,
           BlockNo = d.BlockNo,
           ApplicationUserNo = d.ApplicationUserNo,
           LocationId = d.LocationId,
           IsActive = d.IsActive

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

public async Task<bool> Update(UpdateApplicationUserRequestDto item)
{
   try
   {
       if (item is not null)
       {
           //validation
           var validator = new UpdateApplicationUserRequestValidator();
           validator.Validate(item).throwIfValidationException();
           //set last modify time
           //mapping
           ApplicationUser mappedItem = _autoMapper.Map<ApplicationUser>(item);
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

           bool IsUpdated = await _ApplicationUserRepository.Update(mappedItem);
           if (IsUpdated == true)
               return true;

           return false;
       }

       { return false; }

   }
   catch (Exception ex) { return false; }

}

#endregion
*/
    }
}
