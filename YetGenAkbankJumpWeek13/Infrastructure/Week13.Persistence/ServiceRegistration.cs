using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Application.Repositories.CustomerRepositories;
using Week13.Application.Repositories.ProductRepositories;
using Week13.Persistence.Contexts;
using Week13.Persistence.Repositories.CustomerRepositories;
using Week13.Persistence.Repositories.ProductRepositories;

namespace Week13.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();           
            services.AddDbContext<Week13DbContext>();
        }
    }
}
