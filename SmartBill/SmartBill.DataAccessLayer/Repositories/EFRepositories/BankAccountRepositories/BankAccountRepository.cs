using Microsoft.EntityFrameworkCore;
using SmartBill.DataAccessLayer.Data;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.GenericRepositories;
using SmartBill.Entities.Domains.MSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Repositories.EFRepositories.BankAccountRepositories
{
    public class BankAccountRepository : GenericRepository<BankAccount>, IBankAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public BankAccountRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<BankAccount> GetByIdAsync(string Id)
        {
            try
            {
                
                return await _context.BankAccounts/*.Include(x => x.ApplicationUser)*/.FirstOrDefaultAsync(d => d.Id == Id);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
