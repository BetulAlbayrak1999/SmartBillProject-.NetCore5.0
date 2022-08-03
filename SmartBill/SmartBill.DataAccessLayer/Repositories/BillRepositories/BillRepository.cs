using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.GenericRepositories;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.BillRepositories
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
