﻿using SmartBill.BusinessLogicLayer.Dtos.LocationDto;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using SmartBill.DataAccessLayer.Data;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Services.LocationServices
{
    public class LocationService //: ILocationService
    {
        public Task<bool> Activate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(CreateLocationRequestDto item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllLocationRequestDto>> GetAllActivated()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllLocationRequestDto>> GetAllUnActivated()
        {
            throw new NotImplementedException();
        }

        public Task<GetLocationRequestDto> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnActivate(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateLocationRequestDto item)
        {
            throw new NotImplementedException();
        }
    }
}
