using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.PaymentVM
{
    public class ListPaymentByCustomerVM
    {
        public string  ApplicationUserId { get; set; }

        public string  Email { get; set; }

        public List<string> Payments { get; set; }
    }
}
