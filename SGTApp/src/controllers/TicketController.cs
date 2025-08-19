using SGT.entities;
using SGTApp.dto.TicketDTO;
using SGTApp.services;

namespace SGTApp.controllers;

public class TicketController
{
    private readonly TicketService _ticketService;

    public TicketController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public async Task<List<Ticket>> Listar()
    {
        return await _ticketService.Listar();
    }

    public async Task<TicketGetDTO> Relatorio(long id, DateTime dataInicio, DateTime dataFim)
    {
        return await _ticketService.Relatorio(id, dataInicio,dataFim);
    }

    public async Task<Ticket> Cadastrar(TicketPostDTO dto)
    {
        return await _ticketService.Cadastrar(dto);
    }

    public async Task<Ticket> Editar(TicketPutDTO dto, long id)
    {
        return await _ticketService.Editar(dto, id);
    }
    
}