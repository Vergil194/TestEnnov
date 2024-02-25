using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddPersistenceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opts => opts.UseSqlite(configuration.GetConnectionString("Default")));

            services.AddScoped(typeof(IGeneriqueRepository<>), typeof(GeneriqueRepository<>));

            return services;
        }
    }
}
