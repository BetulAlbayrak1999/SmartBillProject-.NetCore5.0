using SmartBill.Entities.Domains.MongoDB;
using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
        //public virtual ICollection<CreditCard> CreditCards { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public string Description { get; set; }
    }
}
