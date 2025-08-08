using Microsoft.EntityFrameworkCore;
using SGT.entities;

namespace SGTApp.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<HistoricoTicket> HistoricoTickets { get; set; }
}