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

        public byte[] ProfilePicture { get; set; }

        public string ApartmentId { get; set; }

        public string PhoneNumber { get; set; }
        
    }
}
