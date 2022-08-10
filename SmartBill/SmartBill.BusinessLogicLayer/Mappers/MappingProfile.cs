using AutoMapper;
using SmartBill.BusinessLogicLayer.Dtos.ApartmentDto;
using SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto;
using SmartBill.BusinessLogicLayer.Dtos.BankAccountDto;
using SmartBill.BusinessLogicLayer.Dtos.BillDto;
using SmartBill.BusinessLogicLayer.Dtos.BillServerDto;
using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Dtos.MessageDto;
using SmartBill.BusinessLogicLayer.Dtos.RoleDto;
using SmartBill.BusinessLogicLayer.ViewModels.ApartmentVM;
using SmartBill.BusinessLogicLayer.ViewModels.ApplicationUserVM;
using SmartBill.BusinessLogicLayer.ViewModels.BankAccountVM;
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

            CreateMap<CreateApplicationUserRequestDto, ApplicationUser>().ReverseMap();

            CreateMap<UpdateApplicationUserRequestDto, ApplicationUser>().ReverseMap();

            CreateMap<GetApplicationUserRequestDto, ApplicationUser>().ReverseMap();

            CreateMap<ApplicationUserProfileFormVM, ApplicationUser>();

            CreateMap<CheckApplicationUserVM, GetAllApplicationUserRequestDto>().ReverseMap();
            CreateMap<CheckApplicationUserVM, ApplicationUser>().ReverseMap();

            #endregion

            #region Location

            CreateMap<CreateLocationRequestDto, Location>().ReverseMap();

            CreateMap<UpdateLocationRequestDto, Location>().ReverseMap();

            CreateMap<GetLocationRequestDto, Location>().ReverseMap();
            CreateMap<GetAllLocationRequestDto, Location>().ReverseMap();

            #endregion

            #region Apartment

            CreateMap<CreateApartmentRequestDto, Apartment>().ReverseMap();

            CreateMap<UpdateApartmentRequestDto, Apartment>().ReverseMap();

            CreateMap<GetApartmentRequestDto, Apartment>().ReverseMap();

            CreateMap<GetAllApartmentRequestDto, Apartment>().ReverseMap();

            CreateMap<ApartmentListVM, Apartment>().ReverseMap();

            #endregion


            #region BillServer

            CreateMap<CreateBillServerRequestDto, BillServer>().ReverseMap();

            CreateMap<UpdateBillServerRequestDto, BillServer>().ReverseMap();

            CreateMap<GetBillServerRequestDto, BillServer>().ReverseMap();

            CreateMap<GetAllBillServerRequestDto, BillServer>().ReverseMap();

            #endregion

            #region BankAccount

            CreateMap<CreateBankAccountRequestDto, BankAccount>().ReverseMap();

            CreateMap<UpdateBankAccountRequestDto, BankAccount>().ReverseMap();

            CreateMap<GetBankAccountRequestDto, BankAccount>().ReverseMap();

            CreateMap<GetAllBankAccountRequestDto, BankAccount>().ReverseMap();

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

            #region Message

            CreateMap<CreateMessageRequestDto, Message>();

            CreateMap<UpdateMessageRequestDto, Message>();

            CreateMap<GetMessageRequestDto, Message>();

            #endregion
        }

    }
}
