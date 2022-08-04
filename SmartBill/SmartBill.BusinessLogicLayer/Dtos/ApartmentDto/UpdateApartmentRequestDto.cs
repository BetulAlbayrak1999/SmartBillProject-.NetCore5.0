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

        public bool IsEmpty { get; set; }

        public int PersonsNumber { get; set; }

        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

        public DateTime? UnActivedDate { get; set; }
        
        public bool IsActive { get; set; } = false;
        
        public DateTime? ActivedDate { get; set; }
    }
}


