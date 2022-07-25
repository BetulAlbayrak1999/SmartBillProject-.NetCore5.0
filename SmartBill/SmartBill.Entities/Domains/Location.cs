using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class Location : BaseEntity
    {
        public string CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

        public string RegionId { get; set; }
        [ForeignKey(nameof(RegionId))]
        public virtual Region Region { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public ICollection<Apartment> Apartments{ get; set; }
    }
}
