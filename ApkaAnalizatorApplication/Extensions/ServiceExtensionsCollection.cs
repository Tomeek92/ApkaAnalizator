using ApkaAnalizatorApplication.Services.Account;
using ApkaAnalizatorApplication.Services.Analizator;
using ApkaAnalizatorApplication.Services.HL7;
using ApkaAnalizatorDomain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ApkaAnalizatorApplication.Extensions
{
    public static class ServiceExtensionsCollection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAnalizatorServices, AnalizatorServices>();
            services.AddScoped<IHl7Services, Hl7Services>();
            services.AddScoped<IAccountServices, AccountServices>();
        }
    }
}
