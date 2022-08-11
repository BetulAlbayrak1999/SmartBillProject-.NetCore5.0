using SmartBill.Entities.Domains.MongoDB.DocumentBaseEntities;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBill.Entities.Domains.MongoDB
{
    public class CreditCardPayment : DocumentBaseEntity
    {
        public string BillId { get; set; }
        public string BankAccountId { get; set; }
        public bool IsBillPaid { get; set; }

    }
}
