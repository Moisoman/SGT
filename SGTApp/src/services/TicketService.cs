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
    public async Task<TicketGetDTO> Relatorio(long funcionarioId, DateTime dataInicio, DateTime dataFim)
    { 
        //Tratamento das datas, transoformando em UTC para ser compatível com o banco
        dataInicio = dataInicio.ToUniversalTime();
        dataFim = dataFim.ToUniversalTime();
        //Tratando a interpretação das datas para que a query do relatorio funcione com o dia presente
        dataInicio = dataInicio.Date;
        dataFim = dataFim.Date.AddDays(1).AddTicks(-1);
        
        var tickets = await _context.Tickets
            .Where(t => t.FuncionarioId == funcionarioId && t.DataEntrega >= dataInicio && t.DataEntrega <= dataFim)
            .Include(t => t.Funcionario) 
            .ToListAsync();

        if (tickets == null || tickets.Count == 0)
        {
            throw new Exception("Não há Tickets cadastrados para esse Funcionário"); 
        }
        
        var totalQuantidade = tickets.Sum(t => t.Quantidade);
        
        var data = new TicketGetDTO()
        {
            TotalQuantidade = totalQuantidade,
            Situacao = tickets.First().Situacao,
            FuncionarioId = funcionarioId,
            NomeFuncionario = tickets.First().Funcionario.Nome, 
            CpfFuncionario =  tickets.First().Funcionario.Cpf,
            Tickets = tickets.Select(t => new Ticket
            {
                IdTicket = t.IdTicket,
                Situacao = t.Situacao,
                DataEntrega = t.DataEntrega
            }).ToList()
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
            throw new Exception("Funcionário não encontrado ou Identificador de Funcionário Inválido");
        }
        
        Ticket ticket = new Ticket();
        ticket.FuncionarioId = dto.FuncionarioId;
        ticket.Quantidade = 1;
        ticket.Situacao = Ticket.TicketEnum.A;
        ticket.DataEntrega = DateTime.UtcNow; //UtcNow pois é o tipo de datetime compatível com o banco PgSql
        ticket.DataAlteracao = DateTime.UtcNow;
        
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
        
        if (dto.Situacao != null)
        {
            ticketExistente.Situacao = dto.Situacao.Value;
        }
        
        if (erros.Count > 0)
        {
            throw new ValidationException(erros);
        }
        
        ticketExistente.DataAlteracao = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();

        return ticketExistente;
    }
}