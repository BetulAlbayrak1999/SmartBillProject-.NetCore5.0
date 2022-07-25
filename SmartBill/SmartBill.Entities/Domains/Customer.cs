using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class Customer : ApplicationUser
    {
        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<Bill> Bills { get; set; }
    }
}
