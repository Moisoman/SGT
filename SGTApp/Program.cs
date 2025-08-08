using Microsoft.EntityFrameworkCore;
using SGTApp.data;

namespace SGTApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=sgtapp.db");

        using var context = new AppDbContext(optionsBuilder.Options);
        context.Database.EnsureCreated(); 

        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}