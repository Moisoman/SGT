using System.Configuration;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGT.entities;
using SGTApp;
using SGTApp.controllers;
using SGTApp.config;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.dto.TicketDTO;
using SGTApp.services;
using SGTApp.utils;

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
Console.WriteLine($"DB_CONNECTION: {connectionString}");
var services = new ServiceCollection();

services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

FuncionarioController funcionarioController = new FuncionarioController(new FuncionarioService(context));
TicketController ticketController = new TicketController(new TicketService(context));

while (true)
{
    Console.WriteLine("\n--- MENU ---");
    Console.WriteLine("1 - Funcionario");
    Console.WriteLine("2 - Ticket");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha: ");

    var opcaoMenu = Console.ReadLine();

    switch (opcaoMenu)
    {
        // Menu do Funcionario
        case "1":
            Console.WriteLine("\n--- MENU FUNCIONÁRIO ---");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: ");

            var opcaoFuncionario = Console.ReadLine();

            switch (opcaoFuncionario)
            {
                case "1":
                    Console.Write("Nome: ");
                    var nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    var cpf = Console.ReadLine();

                    var funcionario = new FuncionarioPostDTO()
                    {
                        Nome = nome,
                        Cpf = cpf,
                    };

                    try
                    {
                        await funcionarioController.Cadastrar(funcionario);
                        Console.WriteLine($"Funcionário {funcionario.Nome} cadastrado com sucesso.");
                    }
                    catch (ValidationException e)
                    {
                        if (e.Erros != null)
                        {
                            foreach (var erro in e.Erros)
                            {
                                Console.WriteLine(erro);
                            }
                        }
                        else
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    break;

                case "2":
                    var lista = await funcionarioController.Listar();

                    if (lista.Count == 0)
                    {
                        Console.WriteLine("Nenhum usuário encontrado.");
                    }
                    else
                    {
                        foreach (var f in lista)
                        {
                            Console.WriteLine(
                                $"Id:{f.IdFuncionario} \n Nome:{f.Nome} \n CPF:{f.Cpf} \n"
                            );
                        }
                    }
                    break;

                case "3":
                    Console.Write("ID do funcionário a ser editado: ");
                    if (!long.TryParse(Console.ReadLine(), out long id))
                    {
                        Console.WriteLine("Id inserido é inválido.");
                        break;
                    }

                    Console.Write("Novo nome (ou deixe em branco): ");
                    var nomeEditado = Console.ReadLine();

                    Console.Write("Novo CPF (ou deixe em branco): ");
                    var cpfEditado = Console.ReadLine();

                    Console.Write("Nova situação (A ou I) (ou deixe em branco): ");
                    var situacaoStr = Console.ReadLine();

                    Funcionario.SituacaoEnum? situacao = null;

                    if (!string.IsNullOrWhiteSpace(situacaoStr))
                    {
                        if (Enum.TryParse<Funcionario.SituacaoEnum>(situacaoStr, out var situacaoEnum))
                        {
                            situacao = situacaoEnum;
                        }
                        else
                        {
                            Console.WriteLine("Situação inválida. Use 'A' para " +
                                              "funcionarios ativos ou 'I' para funcionários inativos.");
                            break;
                        }
                    }

                    var dtoEdit = new FuncionarioPutDTO
                    {
                        Nome = string.IsNullOrWhiteSpace(nomeEditado) ? null : nomeEditado,
                        Cpf = string.IsNullOrWhiteSpace(cpfEditado) ? null : cpfEditado,
                        Situacao = situacao
                    };

                    try
                    {
                        var fEditado = await funcionarioController.Editar(dtoEdit, id);
                        Console.WriteLine("Registro editado com sucesso:");
                        Console.WriteLine($"Nome: {fEditado.Nome}, CPF: {fEditado.Cpf}, Situação: {fEditado.Situacao}");
                    }
                    catch (ValidationException ex)
                    {
                        foreach (var erro in ex.Erros)
                        {
                            Console.WriteLine(erro);
                        }
                    }
                    break;

                case "0":
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            break;

        // Menu do Ticket
        case "2":
            Console.WriteLine("\n--- MENU TICKET ---");
            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Relatorio por Funcionario");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: ");

            var opcaoTicket = Console.ReadLine();

            switch (opcaoTicket)
            {
                // Cadastrar Ticket
                case "1":
                    Console.Write("FuncionarioId: ");
                    if (!long.TryParse(Console.ReadLine(), out long funcionarioId))
                    {
                        Console.WriteLine("Id de funcionário inválido.");
                        break;
                    }
                    
                    var dtoTicket = new TicketPostDTO()
                    {
                        FuncionarioId = funcionarioId,
                    };

                    try
                    {
                        var ticketCadastrado = await ticketController.Cadastrar(dtoTicket);
                        Console.WriteLine($"Ticket cadastrado com sucesso. ID do Ticket: {ticketCadastrado.IdTicket}");
                    }
                    catch (ValidationException ex)
                    {
                        foreach (var erro in ex.Erros)
                        {
                            Console.WriteLine(erro);
                        }
                    }
                    break;

                // Listar Tickets
                case "2":
                    var listaTickets = await ticketController.Listar();

                    if (listaTickets.Count == 0)
                    {
                        Console.WriteLine("Nenhum ticket encontrado.");
                    }
                    else
                    {
                        foreach (var ticket in listaTickets)
                        {
                            Console.WriteLine(
                                $"Id:{ticket.IdTicket} \n FuncionarioId:{ticket.FuncionarioId} \n " +
                                $"Quantidade:{ticket.Quantidade}" +
                                $" \n Situação:{ticket.Situacao}" +
                                $" \n Data de Entrega:{ticket.DataEntrega}" 
                            );
                        }
                    }
                    break;

                // Editar Ticket
                case "3":
                    Console.Write("ID do ticket a ser editado: ");
                    if (!long.TryParse(Console.ReadLine(), out long ticketId))
                    {
                        Console.WriteLine("Id inserido é inválido.");
                        break;
                    }

                    Console.Write("Nova quantidade (ou deixe em branco): ");
                    var novaQuantidadeStr = Console.ReadLine();
                    long novaQuantidade = long.Parse(novaQuantidadeStr);

                    Console.Write("Nova situação (A ou I) (ou deixe em branco): ");
                    var novaSituacaoStr = Console.ReadLine();
                    Ticket.TicketEnum? novaSituacao = null;

                    if (!string.IsNullOrWhiteSpace(novaSituacaoStr))
                    {
                        if (Enum.TryParse<Ticket.TicketEnum>(novaSituacaoStr, out var situacaoEnum))
                        {
                            novaSituacao = situacaoEnum;
                        }
                        else
                        {
                            Console.WriteLine("Situação inválida. Use 'A' para ativo ou 'I' para inativo.");
                            break;
                        }
                    }

                    var dtoTicketEdit = new TicketPutDTO()
                    {
                        Quantidade = novaQuantidade,
                        Situacao = novaSituacao
                    };

                    try
                    {
                        var ticketEditado = await ticketController.Editar(dtoTicketEdit, ticketId);
                        Console.WriteLine($"Ticket {ticketEditado.IdTicket} editado com sucesso.");
                    }
                    catch (ValidationException ex)
                    {
                        foreach (var erro in ex.Erros)
                        {
                            Console.WriteLine(erro);
                        }
                    }
                    break;

                case "4":
                    Console.Write("Informe o ID do Funcionário: ");
                    if (!long.TryParse(Console.ReadLine(), out long Id))
                    {
                        Console.WriteLine("ID inválido.");
                        break;
                    }

                    Console.Write("Informe a data de início (formato Ano-Mes-Dia): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataInicio))
                    {
                        Console.WriteLine("Data de início inválida.");
                        break;
                    }

                    
                    dataInicio = dataInicio.ToUniversalTime();

                    Console.Write("Informe a data de fim (formato Ano-Mes-dia): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataFim))
                    {
                        Console.WriteLine("Data de fim inválida.");
                        break;
                    }
                    
                    dataFim = dataFim.ToUniversalTime();

                    try
                    {
                        var relatorio = await ticketController.Relatorio(Id, dataInicio, dataFim);
        
                        Console.WriteLine($"\nRelatório de Tickets de {relatorio.NomeFuncionario} ({relatorio.CpfFuncionario}):");
                        Console.WriteLine($"Total de Tickets entregues: {relatorio.TotalQuantidade}");
                        foreach (var ticket in relatorio.Tickets)
                        {
                            Console.WriteLine($"\nTicket ID: {ticket.IdTicket}");
                            Console.WriteLine($"Quantidade: {ticket.Quantidade}");
                            Console.WriteLine($"Situação: {ticket.Situacao}");
                            Console.WriteLine($"Data de Entrega: {ticket.DataEntrega.ToString("yyyy-MM-dd HH:mm:ss")}");
                        }
                    }   
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro: {ex.Message}");
                    }
                    break;

                case "0":
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            break;
        case "0":
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}