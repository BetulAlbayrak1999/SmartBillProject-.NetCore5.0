using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.GenericRepositories;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.BillServerRepositories
{
    public class BillServerRepository : GenericRepository<BillServer>, IBillServerRepository
    {
        public BillServerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
