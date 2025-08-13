using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SGTApp.data;

namespace SGTApp.data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456789;Database=Sgtapp");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}