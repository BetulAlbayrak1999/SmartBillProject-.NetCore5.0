﻿using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class Debt : BaseEntity
    {
        public string BillId { get; set; }
        [ForeignKey(nameof(BillId))]
        public virtual Bill Bill { get; set; }

        public DateTime DebtPaidDate { get; set; }

        public bool IsDebtPaid { get; set; }

    }
}