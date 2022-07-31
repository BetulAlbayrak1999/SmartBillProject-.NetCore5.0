using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.Common
{
    public abstract class BaseEntity : IBaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
        public DateTime? UnActivedDate { get; set; } 
        public bool IsActive { get; set; } = false;
        public DateTime? ActivedDate { get; set; }

    }
}
