using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class Bill : BaseEntity
    {
        public string BillServerId { get; set; }
        [ForeignKey(nameof(BillServerId))]
        public virtual BillServer BillServer { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public bool IsBillPaid { get; set; }

        public DateTime PaidDate { get; set; }

        public float BillAmount { get; set; }

        public float Tax { get; set; }

        public float TotalAmount { get; set; }
    }
}
