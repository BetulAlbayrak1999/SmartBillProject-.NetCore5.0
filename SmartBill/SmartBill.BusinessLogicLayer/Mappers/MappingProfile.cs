using AutoMapper;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using SmartBill.BusinessLogicLayer.Dtos.CityDto;
using SmartBill.BusinessLogicLayer.Dtos.DebtDto;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Dtos.MessageDto;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region ApplicationUser

            CreateMap<CreateApplicationUserRequestDto, ApplicationUser>();

            CreateMap<UpdateApplicationUserRequestDto, ApplicationUser>();

            CreateMap<GetApplicationUserRequestDto, ApplicationUser>();

            #endregion

            #region Apartment

            CreateMap<CreateApartmentRequestDto, Apartment>();

            CreateMap<UpdateApartmentRequestDto, Apartment>();

            CreateMap<GetApartmentRequestDto, Apartment>().ReverseMap();

            #endregion

            #region Bill

            CreateMap<CreateBillRequestDto, Bill>();

            CreateMap<UpdateBillRequestDto, Bill>();

            CreateMap<GetBillRequestDto, Bill>();

            #endregion

            #region BillServer

            CreateMap<CreateBillServerRequestDto, BillServer>();

            CreateMap<UpdateBillServerRequestDto, BillServer>();

            CreateMap<GetBillServerRequestDto, BillServer>();

            #endregion

            #region City

            CreateMap<CreateCityRequestDto, City>();

            CreateMap<UpdateCityRequestDto, City>();

            CreateMap<GetCityRequestDto, City>();

            #endregion

            #region Debt

            CreateMap<CreateDebtRequestDto, Debt>();

            CreateMap<UpdateDebtRequestDto, Debt>();

            CreateMap<GetDebtRequestDto, Debt>();

            #endregion

            #region Location

            CreateMap<CreateLocationRequestDto, Location>();

            CreateMap<UpdateLocationRequestDto, Location>();

            CreateMap<GetLocationRequestDto, Location>();

            #endregion

            #region Message

            CreateMap<CreateMessageRequestDto, Message>();

            CreateMap<UpdateMessageRequestDto, Message>();

            CreateMap<GetMessageRequestDto, Message>();

            #endregion
        }

    }
}
