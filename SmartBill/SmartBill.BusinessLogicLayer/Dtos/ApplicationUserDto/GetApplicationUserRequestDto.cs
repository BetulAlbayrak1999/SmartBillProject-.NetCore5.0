using SmartBill.BusinessLogicLayer.ViewModels.ApartmentVM;
using SmartBill.BusinessLogicLayer.ViewModels.BankAccountVM;
using SmartBill.BusinessLogicLayer.ViewModels.BillVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto
{
    public class GetApplicationUserRequestDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TurkishIdentity { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string VehicleNo { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public DateTime? UnActivatedDate { get; set; }
        public DateTime? ActivatedDate { get; set; }
        public ICollection<ApartmentListVM> Apartments { get; set; }


        public ICollection<BankAccountListVM> BankAccounts { get; set; }

        public ICollection<ApplicationUserBillsVM> Bills { get; set; }
    }
}
