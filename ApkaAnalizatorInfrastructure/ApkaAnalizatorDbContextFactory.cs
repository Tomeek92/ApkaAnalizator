using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace ApkaAnalizatorInfrastructure
{
    public class ApkaAnalizatorDbContextFactory : IDesignTimeDbContextFactory<ApkaAnalizatorDbContext>
    {
        public ApkaAnalizatorDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApkaAnalizatorDbContext>();
            optionsBuilder.UseOracle(configuration.GetConnectionString("ApkaAnalizatorDbContext"));

            return new ApkaAnalizatorDbContext(optionsBuilder.Options);
        }
    }

}











