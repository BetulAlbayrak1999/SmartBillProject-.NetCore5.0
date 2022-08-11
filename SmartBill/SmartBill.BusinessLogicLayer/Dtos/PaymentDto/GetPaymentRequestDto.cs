using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.PaymentDto
{
    public class GetPaymentRequestDto
    {
        public string Id { get; set; }
        public string BillId { get; set; }
        public Bill Bill { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
        public string BillServerId { get; set; }
        public BillServer BillServer { get; set; }
        public bool IsBillPaid { get; set; }
        public float BillAmount { get; set; }
    }
}
