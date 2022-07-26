﻿using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class BankAccount: BaseEntity
    {
        public string BankName { get; set; }
        public string ApplicationUserId { get; set; }
       
        public string IBAN { get; set; }
        public float Balance { get; set; }
    }
}
