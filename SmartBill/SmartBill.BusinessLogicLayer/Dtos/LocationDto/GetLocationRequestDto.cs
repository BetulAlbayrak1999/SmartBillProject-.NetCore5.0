using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.LocationDto
{
    public class GetLocationRequestDto
    {
        public string Id { get; set; }

        public DateTime? UnActivatedDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActivatedDate { get; set; }

        public string City { get; set; }
        public string Region { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
