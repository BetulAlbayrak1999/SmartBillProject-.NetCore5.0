using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBill.DataAccessLayer.Repositories.GenericRepositories;


namespace SmartBill.DataAccessLayer.Repositories.BillRepositories
{
    public interface IBillRepository : IGenericRepository<Bill>
    {
    }
}
