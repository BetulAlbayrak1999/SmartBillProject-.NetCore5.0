using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class Location : BaseEntity
    {
        public string CityName { get; set; }
        public string Street { get; set; }

        public string PostalCode { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
