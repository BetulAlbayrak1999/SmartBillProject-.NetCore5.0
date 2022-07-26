﻿using SmartBill.Entities.Domains.MSSQL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL
{
    public class Apartment : BaseEntity
    {
        public string Name { get; set; }

        public int BlockNo { get; set; }

        public bool IsEmpty { get; set; }

        public int PersonsNumber { get; set; }

        public int FloorNo { get; set; }

        public int ApartmentNo { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual Location Location { get; set; }

    }
}
