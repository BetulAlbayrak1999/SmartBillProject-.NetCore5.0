using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartBill.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.DataAccessLayer.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillServer> BillServers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
    }
}
