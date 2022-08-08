using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.ApartmentVM
{
    public class ApartmentListVM
    {
        public string Name { get; set; }
        public int ApartmentNo { get; set; }
        public string LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}
