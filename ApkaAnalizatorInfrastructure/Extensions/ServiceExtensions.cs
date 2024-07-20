using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ApkaAnalizatorInfrastructure.Repository;
using ApkaAnalizatorDomain.Interfaces;
using Microsoft.AspNetCore.Identity;
using ApkaAnalizatorDomain.Enties;

namespace ApkaAnalizatorInfrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApkaAnalizatorDbContext>(options =>
            options.UseOracle(configuration.GetConnectionString("ApkaAnalizatorDbContext")));

            var configurationn = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            serviceCollection.AddIdentity<Account, IdentityRole>()
         .AddEntityFrameworkStores<ApkaAnalizatorDbContext>()
         .AddSignInManager<SignInManager<Account>>();

            serviceCollection.AddScoped<IAnalizatorRepository,AnalizatorRepository>();
            serviceCollection.AddScoped<IHl7Repository, HL7Repository>();
            serviceCollection.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
