using Microsoft.Extensions.DependencyInjection;
using SmartBill.DataAccessLayer.Repositories.ApartmentRepositories;
using SmartBill.DataAccessLayer.Repositories.ApplicationUserRepositories;
using SmartBill.DataAccessLayer.Repositories.BillRepositories;
using SmartBill.DataAccessLayer.Repositories.BillServerRepositories;
using SmartBill.DataAccessLayer.Repositories.CityRepositories;
using SmartBill.DataAccessLayer.Repositories.DebtRepositories;
using SmartBill.DataAccessLayer.Repositories.GenericRepositories;
using SmartBill.DataAccessLayer.Repositories.LocationRepositories;
using SmartBill.DataAccessLayer.Repositories.MessageRepositories;
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

            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();

            services.AddScoped<IBillServerRepository, BillServerRepository>();

            services.AddScoped<IBillRepository, BillRepository>();

            services.AddScoped<ICityRepository, CityRepository>();

            services.AddScoped<IDebtRepository, DebtRepository>();

            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<ILocationRepository, LocationRepository>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }
    }
}
