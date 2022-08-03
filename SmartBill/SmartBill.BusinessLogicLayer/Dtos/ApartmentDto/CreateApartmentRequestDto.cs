﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.ApartmentDto
{
    public class CreateApartmentRequestDto
    {
        public string Name { get; set; }

        public int BlockNo { get; set; }

        public int PersonsNumber { get; set; }

        public int FloorNo { get; set; }

        public int ApartmentNo { get; set; }

        public string LocationId { get; set; }
    }
}