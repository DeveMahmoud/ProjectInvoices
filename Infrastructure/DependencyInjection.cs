using ApplicationLayer.Iservices;
using Domain.Entities;
using Infrastructure.Irepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<InvoiceDbContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IInvoicerepository, InvoiceRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IITemRepository, ITemRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<JwtTokenGenerator>();


            return services;
        }
    }
}
