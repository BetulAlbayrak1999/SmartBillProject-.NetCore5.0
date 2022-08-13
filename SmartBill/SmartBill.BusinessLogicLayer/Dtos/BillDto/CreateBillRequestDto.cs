using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.BillDto
{
    public class CreateBillRequestDto
    {
        public string BillServerId { get; set; }
        public virtual BillServer BillServer { get; set; }

        public string ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public float BillAmount { get; set; }

        public DateTime BillDate { get; set; } = DateTime.Now;

        public bool IsBillPaid { get; set; } = false;

    }
}
