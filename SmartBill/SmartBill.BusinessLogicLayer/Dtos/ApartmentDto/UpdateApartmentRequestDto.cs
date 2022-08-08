using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.ApartmentDto
{
    public class UpdateApartmentRequestDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PersonsNumber { get; set; }

        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

        public DateTime? UnActivatedDate { get; set; }
        
        public bool IsActive { get; set; } = false;
        public bool IsEmpty { get; set; } = false;
        
        public DateTime? ActivatedDate { get; set; }

    }
}


