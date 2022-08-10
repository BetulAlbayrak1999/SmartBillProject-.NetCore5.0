using Microsoft.Extensions.DependencyInjection;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.ApartmentRepositories;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.BankAccountRepositories;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.BillRepositories;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.BillServerRepositories;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.GenericRepositories;
using SmartBill.DataAccessLayer.Repositories.EFRepositories.LocationRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBill.BusinessLogicLayer.Configrations.Extensions.StartupExtensions
{
    public static class DependencyInjectionRepositoryCollections
    {
        public static void AddDependencyInjectionRepositoryCollections(this IServiceCollection services)
        {
            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            services.AddScoped<IBillServerRepository, BillServerRepository>();

            services.AddScoped<IBankAccountRepository, BankAccountRepository>();

            services.AddScoped<IBillRepository, BillRepository>();

            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }
    }
}
