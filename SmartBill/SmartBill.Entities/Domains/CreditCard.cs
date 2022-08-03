using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class CreditCard: BaseEntity
    {
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }

        public string BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }

        public DateTime ExpireTime { get; set; }
    }
}
