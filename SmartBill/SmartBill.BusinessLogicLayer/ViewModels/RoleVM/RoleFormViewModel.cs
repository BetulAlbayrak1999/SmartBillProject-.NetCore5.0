﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.RoleVM
{
    public class RoleFormViewModel
    {
        [Required]
        [StringLength(100)] 
        public string Name { get; set; }
    }
}
