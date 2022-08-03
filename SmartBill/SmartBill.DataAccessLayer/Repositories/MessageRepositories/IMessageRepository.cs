﻿using SmartBill.DataAccessLayer.Repositories.GenericRepositories;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.MessageRepositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}