using SmartBill.Entities.Domains.MongoDB.DocumentBaseEntities;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBill.Entities.Domains.MongoDB
{
    public class CreditCard : DocumentBaseEntity
    {
        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string CardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }

        public string BankId { get; set; }
        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank { get; set; }


        public virtual ICollection<Payment> Payments { get; set; }

    }
}
