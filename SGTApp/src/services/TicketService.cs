using Microsoft.EntityFrameworkCore;
using SGT.entities;
using SGTApp.data;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.dto.TicketDTO;

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

    public async Task<TicketGetDTO> Relatorio(TicketGetDTO dto, long id)
    { 
        var ticket = await _context.Tickets
            .Include(t => t.Funcionario) 
            .FirstOrDefaultAsync(t => t.IdTicket == id);

        if (ticket == null)
        {
            return null;
        }
        
        var data = new TicketGetDTO()
        {
            IdTicket = ticket.IdTicket,
            Quantidade = ticket.Quantidade,
            Situacao = Ticket.TicketEnum.A,
            FuncionarioId = ticket.FuncionarioId,
            NomeFuncionario = ticket.Funcionario.Nome, 
            CpfFuncionario = ticket.Funcionario.Cpf 
        };

        return data;
    }

    public async Task<TicketPostDTO> Cadastrar(TicketPostDTO dto)
    {
        List<string> erros = new List<string>();

        return dto;

    }

    public async Task<TicketPutDTO> Editar(TicketPutDTO dto)
    {
        List<string> erros = new List<string>();

        return dto;
    }
}