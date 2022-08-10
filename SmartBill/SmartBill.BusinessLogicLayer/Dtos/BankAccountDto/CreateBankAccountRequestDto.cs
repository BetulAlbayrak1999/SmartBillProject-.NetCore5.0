using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.BankAccountDto
{
    public class CreateBankAccountRequestDto
    {
        public string BankName { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string IBAN { get; set; }
        public float Balance { get; set; }

    }
}
