using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class Bill: BaseEntityNoIdentity
    {
        public int BillServerId { get; set; }
        [ForeignKey(nameof(BillServerId))]
        public virtual BillServer BillServer { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public bool IsBillPaid { get; set; }

        public DateTime PaidDate { get; set; }

    }
}
