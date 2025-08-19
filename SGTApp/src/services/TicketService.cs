using Microsoft.EntityFrameworkCore;
using SGT.entities;
using SGTApp.data;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.dto.TicketDTO;
using SGTApp.utils;

namespace SGTApp.services;

/**
 * Serviço de Ticket do Sistema(Ler,Cadastrar,Editar,Relatorio)
 */
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

    /**
     * Metodo para gerar um relatorio de tickets distribuídos para um determinado funcionario
     */
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
    /**
     * Metodo para cadastrar um Ticket no sistema 
     */
    public async Task<Ticket> Cadastrar(TicketPostDTO dto)
    {
        List<string> erros = new List<string>();

        if (dto.FuncionarioId == null || dto.FuncionarioId < 0)
        {
            erros.Add("Identificador de Funcionário inválido");
        }

        if (dto.Quantidade <= 0)
        {
            erros.Add("Quantidade Inválida: deve pelo menos entregar uma unidade de Ticket");
        }

        if (dto.Situacao == Ticket.TicketEnum.I)
        {
            erros.Add("Situação Inválida: Não é possível cadastrar um ticket como inativo");
        }

        if (erros.Count > 0)
        {
            throw new ValidationException(erros);
        }

        Ticket ticket = new Ticket();
        ticket.FuncionarioId = dto.FuncionarioId;
        ticket.Quantidade = dto.Quantidade;
        ticket.Situacao = Ticket.TicketEnum.A;
        ticket.DataEntrega = DateTime.UtcNow; //UtcNow pois é o tipo de datetime compatível com o banco PgSql
        
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
        
        return ticket;

    }
    
    /**
     * Metodo para Editar um registro de um Ticket no Sistema
     */
    public async Task<Ticket> Editar(TicketPutDTO dto, long id)
    {
        List<string> erros = new List<string>();
        var ticketExistente = await _context.FindAsync<Ticket>(id);

        if (ticketExistente == null)
        {
            erros.Add("Ticket não encontrado.");
            throw new ValidationException(erros);
        }
        
        if (dto.FuncionarioId != null)
        {
            if (dto.FuncionarioId < 0)
            {
                erros.Add("Identificador de Funcionário inválido.");
            }
            else
            {
                ticketExistente.FuncionarioId = dto.FuncionarioId;
            }
        }
        
        if (dto.Quantidade != null)
        {
            if (dto.Quantidade < 0)
            {
                erros.Add("A quantidade de Tickets deve ser maior que zero");
            }
            else
            {
                ticketExistente.Quantidade = dto.Quantidade;
            }
        }
        
        if (dto.Situacao != null)
        {
            ticketExistente.Situacao = dto.Situacao;
        }
        
        if (erros.Count > 0)
        {
            throw new ValidationException(erros);
        }
        
        ticketExistente.DataEntrega = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return ticketExistente;
    }
}