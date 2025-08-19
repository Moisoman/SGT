using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SGT.entities;
using SGTApp.data;
using SGTApp.dto.TicketDTO;
using SGTApp.services;
using SGTApp.utils;

namespace SGTApp.Tests.services;

[TestFixture]
public class TicketServiceTest
{
    private AppDbContext _context;
    private TicketService _ticketService;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _ticketService = new TicketService(_context);        
    }
    
    [Test]
    public async Task Listar_DeveRetornarTodosTickets()
    {
        // Given
        var tickets = new List<Ticket>
        {
            new Ticket { IdTicket = 1, Quantidade = 10, Situacao = Ticket.TicketEnum.A },
            new Ticket { IdTicket = 2, Quantidade = 5, Situacao = Ticket.TicketEnum.A }
        };
        
        await _ticketService.Cadastrar(new TicketPostDTO { FuncionarioId = 1, Quantidade = 10, Situacao = Ticket.TicketEnum.A });
        await _ticketService.Cadastrar(new TicketPostDTO { FuncionarioId = 2, Quantidade = 5, Situacao = Ticket.TicketEnum.A });

        // When
        var result = await _ticketService.Listar();

        // Then
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(10, result[0].Quantidade);
        Assert.AreEqual(5, result[1].Quantidade);
    }
    
    [Test]
    public async Task Relatorio_DeveRetornarTicketComFuncionario()
    {
        // Given
        var ticket = new Ticket { IdTicket = 1, FuncionarioId = 1, Quantidade = 10, Situacao = Ticket.TicketEnum.A };
        var funcionario = new Funcionario { IdFuncionario = 1, Nome = "João", Cpf = "12345678901" };

        await _ticketService.Cadastrar(new TicketPostDTO { FuncionarioId = 1, Quantidade = 10, Situacao = Ticket.TicketEnum.A });
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();

        // When
        var result = await _ticketService.Relatorio(new TicketGetDTO(), 1);

        // Then
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.IdTicket);
        Assert.AreEqual("João", result.NomeFuncionario);
        Assert.AreEqual("12345678901", result.CpfFuncionario);
    }
    
    [Test]
    public async Task Cadastrar_DeveCriarTicketComSucesso()
    {
        // Given
        var dto = new TicketPostDTO { FuncionarioId = 1, Quantidade = 10, Situacao = Ticket.TicketEnum.A };

        // When
        var result = await _ticketService.Cadastrar(dto);

        // Then
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.FuncionarioId);
        Assert.AreEqual(10, result.Quantidade);
        Assert.AreEqual(Ticket.TicketEnum.A, result.Situacao);
    }
    
    [Test]
    public void Cadastrar_DeveLancarExceptionQuandoFuncionarioIdInvalido()
    {
        // Given
        var dto = new TicketPostDTO { FuncionarioId = -1, Quantidade = 10, Situacao = Ticket.TicketEnum.A };

        // When / Then
        var ex = Assert.ThrowsAsync<ValidationException>(async () => await _ticketService.Cadastrar(dto));
        Assert.AreEqual("Identificador de Funcionário inválido", ex.Erros[0]);
    }
    
    [Test]
    public async Task Editar_DeveAtualizarTicketComSucesso()
    {
        // Given
        
        var ticket = new Ticket()
        {
            FuncionarioId = 1,
            Quantidade = 10,
            Situacao = Ticket.TicketEnum.A
        };
        
        await _context.Tickets.AddAsync(ticket);
        
        var dto = new TicketPutDTO
        {
            FuncionarioId = 2, 
            Quantidade = 20, 
            Situacao = Ticket.TicketEnum.A
        };
        
        // When
        var result = await _ticketService.Editar(dto, ticket.IdTicket);

        // Then
        Assert.AreEqual(2, result.FuncionarioId); 
        Assert.AreEqual(20, result.Quantidade); 
        Assert.AreEqual(Ticket.TicketEnum.A, result.Situacao);
    }
    
    [Test]
    public void Editar_DeveLancarExceptionQuandoTicketNaoExistir()
    {
        // Given
        var dto = new TicketPutDTO { FuncionarioId = 2, Quantidade = 20, Situacao = Ticket.TicketEnum.A };

        // When / Then
        var ex = Assert.ThrowsAsync<ValidationException>(async () => await _ticketService.Editar(dto, 9999)); // ID inexistente
        Assert.AreEqual("Ticket não encontrado.", ex.Erros[0]);
    }





    
}