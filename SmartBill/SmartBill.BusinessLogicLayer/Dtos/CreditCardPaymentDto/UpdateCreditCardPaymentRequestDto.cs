using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.CreditCardPaymentDto
{
    public class UpdateCreditCardPaymentRequestDto
    {
        public ObjectId Id { get; set; }
        public string BillId { get; set; }
        public bool IsBillPaid { get; set; }

    }
}
