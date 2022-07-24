using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class Apartment: BaseEntityNoIdentity
    {
        public string Name { get; set; }

        public int BlockNo { get; set; }

        public bool IsEmpty { get; set; }

        public int Area { get; set; }

        public int FloorNo { get; set; }

        public int ApartmentNo { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }

    }
}
