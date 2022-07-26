using SmartBill.BusinessLogicLayer.Abstract;
using SmartBill.DataAccessLayer.Abstract;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services
{
    public class BillService : GenericService<Bill>, IBillService
    {
    }
}
