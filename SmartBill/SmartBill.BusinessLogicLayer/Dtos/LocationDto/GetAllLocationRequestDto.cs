using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.LocationDto
{
    public class GetAllLocationRequestDto
    {
        public string Id { get; set; }

        public bool IsActive { get; set; }

        public string City { get; set; }
        public string Region { get; set; }

        public string Street { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
