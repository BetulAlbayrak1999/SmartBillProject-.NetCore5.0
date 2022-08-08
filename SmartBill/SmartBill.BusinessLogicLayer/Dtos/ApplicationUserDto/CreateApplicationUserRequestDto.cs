using SmartBill.BusinessLogicLayer.ViewModels.RoleVM;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.ApplicationUserDto
{
    public class CreateApplicationUserRequestDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TurkishIdentity { get; set; }

        public string Gender { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public List<GetRoleVM> Roles { get; set; }

    }
}

/*
public ICollection<Apartment> Apartments { get; set; }

public ICollection<BankAccount> BankAccounts { get; set; }

public ICollection<Bill> Bills { get; set; }*/