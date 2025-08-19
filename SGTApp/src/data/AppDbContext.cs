using Microsoft.EntityFrameworkCore;
using SGT.entities;

namespace SGTApp.data;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>()
            .Property(f => f.Situacao)
            .HasConversion<string>();

        base.OnModelCreating(modelBuilder);
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}