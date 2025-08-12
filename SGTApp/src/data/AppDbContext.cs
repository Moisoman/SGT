using Microsoft.EntityFrameworkCore;
using SGT.entities;

namespace SGTApp.data;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=sgtAppDb.db");
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<HistoricoTicket> HistoricoTickets { get; set; }
}