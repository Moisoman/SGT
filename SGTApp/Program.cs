using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SGT.entities;
using SGTApp.controllers;
using SGTApp.data;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.services;
using SGTApp.utils;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=123456789;Database=Sgtapp"));


var serviceProvider = services.BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

FuncionarioController funcionarioController = new FuncionarioController(new FuncionarioService(context));

while (true)
{
    Console.WriteLine("\n--- MENU FUNCIONÁRIO ---");
    Console.WriteLine("1 - Cadastrar");
    Console.WriteLine("2 - Listar");
    Console.WriteLine("3 - Editar");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha: ");
    
    var opcao = Console.ReadLine();

    switch (opcao)
    {
        //Cadastrar um funcionario
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
        //Listar os funcionarios
        case "2":
            
            var lista =await funcionarioController.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum usuário encontrado.");
            }
            else
            {
                foreach (var f in lista )
                {
                    Console.WriteLine(
                        $"Id:{f.IdFuncionario} \n Nome:{f.Nome} \n CPF:{f.Cpf} \n"
                        );
                }
            }
            break;
        
        //Editar um Funcionario
        case "3":
            Console.Write("ID do funcionário a ser editado: ");
            if (!long.TryParse(Console.ReadLine(), out long id))
            {
                Console.WriteLine("Id inserido é inválido inválido");
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
                Console.WriteLine("Registo editado com sucesso:");
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
            return;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}