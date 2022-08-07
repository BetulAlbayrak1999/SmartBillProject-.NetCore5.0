using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBill.DataAccessLayer.Repositories.GenericRepositories;
using SmartBill.Entities.Domains.MSSQL;

namespace SmartBill.DataAccessLayer.Repositories.BillRepositories
{
    public interface IBillRepository : IGenericRepository<Bill>
    {
    }
}
