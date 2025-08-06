using Microsoft.EntityFrameworkCore;
using SGT.entities;

namespace SGTApp.data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    {
        
    }
    
    DbSet<Funcionario> Funcionarios { get; set; }
    DbSet<Ticket> Tickets { get; set; }
    DbSet<HistoricoTicket> HistoricoTickets { get; set; }
}