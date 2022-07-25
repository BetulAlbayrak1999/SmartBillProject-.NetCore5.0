using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class MessageRecipient: BaseEntity
    {
        /*public ICollection<Message> Messages { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public int AdminId { get; set; }
        [ForeignKey(nameof(AdminId))]
        public virtual Admin Admin { get; set; }*/

        public bool IsRead { get; set; }
    }
}
