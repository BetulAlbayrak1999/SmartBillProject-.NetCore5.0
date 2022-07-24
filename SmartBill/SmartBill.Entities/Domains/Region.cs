﻿using SmartBill.Entities.Domains.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains
{
    public class Region : BaseEntityNoIdentity
    {
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

    }
}
