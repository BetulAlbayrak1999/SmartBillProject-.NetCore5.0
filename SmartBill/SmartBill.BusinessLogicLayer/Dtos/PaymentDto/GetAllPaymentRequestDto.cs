using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.PaymentDto
{
    public class GetAllPaymentRequestDto
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BillId { get; set; }
        public string BankAccountId { get; set; }
        public string ApplicationUserId { get; set; }
        public bool IsBillPaid { get; set; }
    }
}
