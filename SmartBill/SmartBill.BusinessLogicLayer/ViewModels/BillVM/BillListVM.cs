using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.BillVM
{
    public class BillListVM
    {
        public string BillServerId { get; set; }
        public virtual BillServer BillServer { get; set; }
        public bool IsBillPaid { get; set; }

        public DateTime? PaidDate { get; set; }

        public float TotalAmount { get; set; }
    }
}
