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
    public abstract class GenericService<TModel>
        : IGenericService<TModel>
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
