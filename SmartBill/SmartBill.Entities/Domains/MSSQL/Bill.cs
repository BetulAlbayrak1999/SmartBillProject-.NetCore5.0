using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class Bill : BaseEntity
    {
        public string BillServerId { get; set; }

        public string ApartmentId { get; set; }

        public float BillAmount { get; set; }

        public DateTime BillDate { get; set; } = DateTime.Now;

        public bool IsBillPaid { get; set; }

    }
}
