using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.CreditCardPaymentDto
{
    public class CreateCreditCardPaymentRequestDto
    {
        public string BillId { get; set; }
        public string BankAccountId { get; set; }
        public bool IsBillPaid { get; set; }
    }
}
