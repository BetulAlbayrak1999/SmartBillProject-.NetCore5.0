using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.ApartmentDto
{
    public class GetApartmentRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int BlockNo { get; set; }

        public bool IsEmpty { get; set; }
        public bool IsActive { get; set; }

        public int PersonsNumber { get; set; }

        public int FloorNo { get; set; }

        public int ApartmentNo { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public DateTime? UnActivedDate { get; set; }
        public DateTime? ActivedDate { get; set; }
    }
}
