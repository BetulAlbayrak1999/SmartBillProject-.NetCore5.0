﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.ViewModels.ApplicationUserVM
{
    public class ApplicationUserProfileFormVM
    {

        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }

        public string UserName { get; set; }

        public string? VehicleNo { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime LastModifiedDate { get; set; } = DateTime.Now;

        public DateTime? UnActivatedDate { get; set; }

        public bool IsActive { get; set; } = false;

        public DateTime? ActivatedDate { get; set; }
    }
}
