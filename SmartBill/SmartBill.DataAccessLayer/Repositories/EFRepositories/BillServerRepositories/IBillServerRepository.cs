﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.GenericRepositories;
using SmartBill.Entities.Domains.MSSQL;

namespace SmartBill.DataAccessLayer.Repositories.EFRepositories.BillServerRepositories
{
    public interface IBillServerRepository : IGenericRepository<BillServer>
    {
    }
}
