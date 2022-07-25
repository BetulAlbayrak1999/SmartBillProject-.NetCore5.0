﻿using SmartBill.DataAccessLayer.Abstract;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories
{
    public class DebtRepository : GenericRepository<Debt>, IDebtRepository
    {
        public DebtRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}