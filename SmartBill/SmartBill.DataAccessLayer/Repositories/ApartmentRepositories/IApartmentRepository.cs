using SmartBill.DataAccessLayer.Repositories;
using SmartBill.DataAccessLayer.Repositories.GenericRepositories;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.ApartmentRepositories
{
    public interface IApartmentRepository : IGenericRepository<Apartment>
    {
    }
}
