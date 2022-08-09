using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.BillServerDto
{
    public class GetBillServerRequestDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public DateTime? UnActivatedDate { get; set; }

        public DateTime? ActivatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
