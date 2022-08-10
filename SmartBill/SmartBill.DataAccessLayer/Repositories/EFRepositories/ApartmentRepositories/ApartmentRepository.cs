using Microsoft.EntityFrameworkCore;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.GenericRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.EFRepositories.ApartmentRepositories
{
    public class ApartmentRepository : GenericRepository<Apartment>, IApartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public ApartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Apartment> GetByIdAsync(string Id)
        {
            try
            {
                return await _context.Apartments.Include(x => x.ApplicationUser).Include(x=> x.Location).FirstOrDefaultAsync(d=> d.Id == Id);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

      
    }
}