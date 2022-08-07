using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class BankAccount: BaseEntity
    {
        public string BankName { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string CardNumber { get; set; }
        public int CardExpireMonth { get; set; }
        public int CardExpireYear { get; set; }

    }
}
