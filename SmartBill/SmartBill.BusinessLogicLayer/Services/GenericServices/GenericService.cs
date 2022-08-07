using AutoMapper;
using FluentValidation;
using SmartBill.BusinessLogicLayer.Configrations.Extensions.Exceptions;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.GenericServices
{
    public abstract class GenericService<TCreateDto, TCreateValid, TGetDto, TGetAllDto, TModel>
        : IGenericService<TCreateDto, TCreateValid, TGetDto, TGetAllDto, TModel>
        where TCreateDto : class, new()
        where TCreateValid : AbstractValidator<TCreateDto>, new()
        where TGetDto : class, new()
        where TGetAllDto : class, new()
        where TModel : class, new()
    {
        #region Field and Constructor
        private readonly IMapper _autoMapper;
        private readonly IGenericRepository<TModel> _genericRepository;

        public GenericService(IMapper autoMapper, IGenericRepository<TModel> genericRepository)
        {
            _autoMapper = autoMapper;
            _genericRepository = genericRepository;
        }
        #endregion


        #region Create
        public async Task<CommandResponse> CreateAsync(TCreateDto item)
        {
            try
            {
                if (item is not null)
                {
                    //validation
                    var validator = new TCreateValid();
                    validator.Validate(item).throwIfValidationException();

                    //mapping
                    TModel mappedItem = _autoMapper.Map<TModel>(item);
                    var IsCreated = await _genericRepository.CreateAsync(mappedItem);
                    if (IsCreated == true)
                        return new CommandResponse { Status = true, Message = "This operation has not done successfully" };
                    return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
                }

                { return new CommandResponse { Status = false, Message = "This operation has not done successfully" }; }

            }
            catch (Exception ex) { return new CommandResponse { Status = false, Message = ex.Message }; }
        }

        #endregion


        #region GetByIdAsync
        public async Task<TGetDto> GetByIdAsync(string Id)
        {
            try
            {
                if (Id is not null)
                {
                    TModel item = await _genericRepository.GetByIdAsync(Id);
                    if (item is not null)
                    {
                        //mapping
                        TGetDto mappedItem = _autoMapper.Map<TGetDto>(item);

                        return mappedItem;
                    }
                    return null;
                }

                { return null; }

            }
            catch (Exception ex) { return null; }
        }

        #endregion

        

        #region DeleteAsync
        public async Task<CommandResponse> DeleteAsync(string Id)
        {
            try
            {
                 bool IsDeleted = await _genericRepository.DeleteAsync(Id);
                if(IsDeleted)
                    return new CommandResponse { Status = true, Message = "This operation has not done successfully" };

                return new CommandResponse { Status = false, Message = "This operation has not done successfully" };
            }
            catch (Exception ex)
            {
                return new CommandResponse { Status = false, Message = ex.Message };
            }
        }

        #endregion

    }
}
