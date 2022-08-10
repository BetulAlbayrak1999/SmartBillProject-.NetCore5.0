using Microsoft.Extensions.DependencyInjection;
using SmartBill.BusinessLogicLayer.Services.AppartmentServices;
using SmartBill.BusinessLogicLayer.Services.ApplicationUserServices;
using SmartBill.BusinessLogicLayer.Services.BillServerServices;
using SmartBill.BusinessLogicLayer.Services.BillServices;
using SmartBill.BusinessLogicLayer.Services.LocationServices;
using SmartBill.BusinessLogicLayer.Services.GenericServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBill.BusinessLogicLayer.Services.BankAccountServices;

namespace SmartBill.BusinessLogicLayer.Configrations.Extensions.StartupExtensions
{
    public static class DependencyInjectionServiceCollections
    {
        public static void AddDependencyInjectionServiceCollections (this IServiceCollection services)
        {
            services.AddScoped<IApartmentService, ApartmentService>();

            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            services.AddScoped<IBillServerService, BillServerService>();

            services.AddScoped<IBankAccountService, BankAccountService>();

            services.AddScoped<IBillService, BillService>();

            services.AddScoped<ILocationService, LocationService>();
        }
    }
}
