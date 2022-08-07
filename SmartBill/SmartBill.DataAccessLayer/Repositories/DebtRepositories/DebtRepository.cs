using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.GenericRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.DebtRepositories
{
    public class DebtRepository : GenericRepository<Debt>, IDebtRepository
    {
        public DebtRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
