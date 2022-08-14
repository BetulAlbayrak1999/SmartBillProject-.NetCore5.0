using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Configrations.Helpers
{
    public class CalculatorHelperx
    {
        public float CalculateCommission(float price)
        {
            var commision = price * (float)0.02;
            return commision;
        }

        public float CalculateVAT(float price, float rate)
        {
            var vat = (price * (float)rate) / 100;
            return vat;
        }
    }
}
