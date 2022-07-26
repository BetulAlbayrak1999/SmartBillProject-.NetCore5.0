﻿using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class BillServer : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Bill> Bills { get; set; }

    }
}
