using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.BillDto
{
    public class GetBillRequestDto
    {
        public string Id { get; set; }
        public string BillServerId { get; set; }
        public virtual BillServer BillServer { get; set; }

        public string ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        public float BillAmount { get; set; }

        public DateTime PaidDate { get; set; } = DateTime.Now;

        public bool IsBillPaid { get; set; } = false;

        public DateTime LastModifiedDate { get; set; }
    }
}
