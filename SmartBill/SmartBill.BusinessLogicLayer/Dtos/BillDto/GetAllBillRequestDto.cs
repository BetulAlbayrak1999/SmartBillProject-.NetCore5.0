using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.BillDto
{
    public class GetAllBillRequestDto
    {
        public string Id { get; set; }
        public string BillServerId { get; set; }

        public string ApartmentId { get; set; }
        public string ApplicationUserId { get; set; }

        public float BillAmount { get; set; }

        public bool IsBillPaid { get; set; } 

        public DateTime LastModifiedDate { get; set; }
    }
}
