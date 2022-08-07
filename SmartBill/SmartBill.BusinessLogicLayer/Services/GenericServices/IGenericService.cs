using FluentValidation;
using SmartBill.BusinessLogicLayer.Configrations.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.GenericServices
{
    public interface IGenericService<TCreateDto, TCreateValid, TGetDto, TGetAllDto, TModel>
        where TCreateDto : class, new()
        where TCreateValid : AbstractValidator<TCreateDto>, new()
        where TGetDto : class, new()
        where TGetAllDto : class, new()
        where TModel : class, new()
    {
        public Task<CommandResponse> CreateAsync(TCreateDto item);

        public Task<TGetDto> GetByAsync(Expression<Func<TGetDto, bool>> predicate = null);

        public Task<TGetDto> GetByIdAsync(string Id);
 
        public Task<IEnumerable<TGetAllDto>> GetAllByAsync(Expression<Func<TGetAllDto, bool>> expression = null);

        public Task<CommandResponse> DeleteAsync(string Id);    

    }
}
