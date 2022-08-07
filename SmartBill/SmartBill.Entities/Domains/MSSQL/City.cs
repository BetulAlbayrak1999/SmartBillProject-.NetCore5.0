using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
