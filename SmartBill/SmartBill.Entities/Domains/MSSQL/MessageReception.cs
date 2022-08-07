using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class MessageReception : BaseEntity
    {
        /*public ICollection<Message> Messages { get; set; }

        public int MessageSendingId { get; set; }
        [ForeignKey(nameof(MessageSendingId))]
        public virtual MessageSending MessageSending { get; set; }*/
    }
}
