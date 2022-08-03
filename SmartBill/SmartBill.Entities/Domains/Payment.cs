using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class Payment: BaseEntity
    {
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string CreditCardId { get; set; }
        [ForeignKey(nameof(CreditCardId))]
        public virtual CreditCard CreditCard { get; set; }

        public string BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }
    }
}
