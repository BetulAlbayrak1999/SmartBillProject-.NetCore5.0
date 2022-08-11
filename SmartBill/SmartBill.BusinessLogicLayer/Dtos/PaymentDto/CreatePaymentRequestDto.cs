using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.PaymentDto
{
    public class CreatePaymentRequestDto
    {
        public string Id { get; set; }
        public string BillId { get; set; }
        public string BankAccountId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsBillPaid { get; set; }
    }
}
