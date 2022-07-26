﻿using SmartBill.DataAccessLayer.Repositories.EFRepositories.GenericRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.EFRepositories.ApartmentRepositories
{
    public interface IApartmentRepository : IGenericRepository<Apartment>
    {
    }
}
