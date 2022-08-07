using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TurkishIdentity { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string VehicleNo { get; set; }


        public ICollection<Apartment> Apartments { get; set; }


        public ICollection<BankAccount> BankAccounts { get; set; }

        public ICollection<Bill> Bills { get; set; }

        //public ICollection<MessageSending> MessageSendings { get; set; }

    }
}
