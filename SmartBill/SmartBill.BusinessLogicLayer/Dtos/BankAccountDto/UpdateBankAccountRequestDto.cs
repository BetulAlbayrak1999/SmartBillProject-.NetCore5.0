using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.BankAccountDto
{
    public class UpdateBankAccountRequestDto
    {
        public string Id { get; set; }
        public string BankName { get; set; }
        public float Balance { get; set; }
      
        public bool IsActive { get; set; }

        public DateTime? UnActivatedDate { get; set; }

        public DateTime? ActivatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
