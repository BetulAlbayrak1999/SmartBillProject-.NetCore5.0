using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.ApartmentDto
{
    public class GetAllApartmentRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public bool IsEmpty { get; set; }

        public int PersonsNumber { get; set; }

        public int FloorNo { get; set; }

        public int BlockNo { get; set; }

        public int ApartmentNo { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }

        public bool IsActive { get; set; }

    }
}