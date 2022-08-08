using AutoMapper;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Dtos.MessageDto;
using SmartBill.BusinessLogicLayer.Dtos.RoleDto;
using SmartBill.BusinessLogicLayer.ViewModels.ApartmentVM;
using SmartBill.BusinessLogicLayer.ViewModels.ApplicationUserVM;
using SmartBill.BusinessLogicLayer.ViewModels.RoleVM;
using SmartBill.Entities.Domains.MSSQL;
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

            CreateMap<UpdateApplicationUserRequestDto, ApplicationUser>().ReverseMap();

            CreateMap<GetApplicationUserRequestDto, ApplicationUser>();

            CreateMap<ApplicationUserProfileFormVM, ApplicationUser>();

            #endregion

            #region Apartment

            CreateMap<CreateApartmentRequestDto, Apartment>();

            CreateMap<UpdateApartmentRequestDto, Apartment>();

            CreateMap<GetApartmentRequestDto, Apartment>().ReverseMap();

            CreateMap<GetAllApartmentRequestDto, Apartment>().ReverseMap();

            CreateMap<ApartmentListVM, Apartment>().ReverseMap();

            #endregion

            #region Role
            CreateMap<GetRoleRequestDto, GetRoleVM>().ReverseMap();

            #endregion

            #region Bill

            CreateMap<CreateBillRequestDto, Bill>();

            CreateMap<UpdateBillRequestDto, Bill>();

            CreateMap<GetBillRequestDto, Bill>();

            CreateMap<GetAllBillRequestDto, Bill>().ReverseMap();


            #endregion

            #region BillServer

            CreateMap<CreateBillServerRequestDto, BillServer>();

            CreateMap<UpdateBillServerRequestDto, BillServer>();

            CreateMap<GetBillServerRequestDto, BillServer>();

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
