using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public abstract class Person : BaseEntityWithIdentity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TC { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        public DateTime? Birthdate { get; set; }

        public string ImagePath { get; set; }

        public string VehicleNo { get; set; }

    }
}
