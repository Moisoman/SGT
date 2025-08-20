using System.Configuration;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SGTApp.config;

namespace SGTApp.config
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            Env.Load();
            
            var configuration = Environment.GetEnvironmentVariable("DB_CONNECTION"); ;
            
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(configuration);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}