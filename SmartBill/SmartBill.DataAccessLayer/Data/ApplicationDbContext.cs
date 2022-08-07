using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartBill.Entities.Domains.MSSQL;

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

        //public virtual DbSet<MessageSending> MessageSendings { get; set; }
        //public virtual DbSet<MessageReception> MessageReceptions { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users", "security");/*.Ignore(e=> e.PhoneNumber)*/
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

            builder.Entity<ApplicationUser>()
            .HasAlternateKey(c => c.TurkishIdentity)
            .HasName("AlternateKey_TurkishIdentity");
            builder.Entity<ApplicationUser>()
            .HasAlternateKey(c => c.UserName)
            .HasName("AlternateKey_UserName");
            builder.Entity<ApplicationUser>()
            .HasAlternateKey(c => c.Email)
            .HasName("AlternateKey_Email");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
