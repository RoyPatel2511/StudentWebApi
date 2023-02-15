using Demostudentweb.Infra.Domain;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;


namespace Demostudentweb.Configuration
{
    public static class SqlServerConfiguration
    {
        
        public static void AddSqlServer(this IServiceCollection services, IConfiguration configuration)

        { 
            var connectionString = configuration["ConnectionStrings:ConStr"];

            services.AddDbContext<DemostudentwebContext>(options =>
            {
                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("Demostudentweb.Infra.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            },ServiceLifetime.Singleton);
        }
    }
}
