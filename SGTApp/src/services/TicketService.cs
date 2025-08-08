using Microsoft.EntityFrameworkCore;
using SGT.entities;
using SGTApp.data;
using SGTApp.dto.FuncionarioDTO;

namespace SGTApp.services;

public class TicketService
{
    private readonly AppDbContext _context;

    public TicketService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> Listar()
    {
        return await _context.Tickets.ToListAsync();
    }

    public async Task<Ticket> Ler(long id)
    {
        return await _context.Tickets.FindAsync(id);
    }

    public async Task<Ticket> Cadastrar(FuncionarioPostDTO dto)
    {
        List<string> erros = new List<string>();
        
        
    }
}