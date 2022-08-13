using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.Entities.Domains.MSSQL.Common
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime LastModifiedDate { get; set; } 
        public DateTime? UnActivatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ActivatedDate { get; set; }

    }
}
