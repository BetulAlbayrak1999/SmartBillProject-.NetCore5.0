using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TurkishIdentity { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public byte[] ProfilePicture { get; set; }

        public string? VehicleNo { get; set; }

        public string ApartmentId { get; set; }
        [ForeignKey(nameof(ApartmentId))]
        public virtual Apartment Apartment { get; set; }


        //public ICollection<CreditCard> CreditCards { get; set; }

        public ICollection<Bill> Bills { get; set; }

        public ICollection<Payment> Payments { get; set; }
        //public ICollection<MessageSending> MessageSendings { get; set; }

    }
}
