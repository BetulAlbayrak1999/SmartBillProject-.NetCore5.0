using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Dtos.CityDto
{
    public class CreateCityRequestDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
