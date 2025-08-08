using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SGT.entities;
using SGTApp.data;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.services;
using SGTApp.utils;

namespace SGTApp.Tests.services
{
    [TestFixture]
    public class FuncionarioServiceTests
    {
        private AppDbContext _context;
        private FuncionarioService _service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            _context = new AppDbContext(options);
            _service = new FuncionarioService(_context);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task AdicionarFuncionarioDeveRetornarFuncionarioValido()
        {
            // Given
            var dto = new FuncionarioPostDTO
            {
                Nome = "Maria",
                Cpf = "12345678900"
            };

            // When
            var resultado = await _service.Casdatrar(dto);

            // Then
            Assert.IsNotNull(resultado);
            Assert.AreEqual("Maria", resultado.Nome);
            Assert.AreEqual("12345678900", resultado.Cpf);
            Assert.AreEqual(Funcionario.SituacaoEnum.A, resultado.Situacao);
        }

        [Test]
        public void AdicionarFuncionarioInvalidoDeveLancarValidationException()
        {
            // Given
            var dto = new FuncionarioPostDTO
            {
                Nome = "", 
                Cpf = null 
            };

            // When / Then
            var ex = Assert.ThrowsAsync<ValidationException>(async () => await _service.Casdatrar(dto));
            Assert.That(ex.Erros, Does.Contain("Nome inserido é invalido"));
            Assert.That(ex.Erros, Does.Contain("Cpf inserido é invalido"));
        }

        [Test]
        public async Task AtualizarFuncionarioExistenteDeveAlterarDados()
        {
            // Given
            var funcionario = new Funcionario
            {
                Nome = "Antigo",
                Cpf = "00000000000",
                Situacao = Funcionario.SituacaoEnum.I,
                DataAlteracao = DateTime.Now
            };
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();

            var dto = new FuncionarioPutDTO
            {
                Nome = "Atualizado",
                Cpf = "11111111111",
                Situacao = Funcionario.SituacaoEnum.A
            };

            // When
            var resultado = await _service.Editar(dto, funcionario.IdFuncionario);

            // Then
            Assert.AreEqual("Atualizado", resultado.Nome);
            Assert.AreEqual("11111111111", resultado.Cpf);
            Assert.AreEqual(Funcionario.SituacaoEnum.A, resultado.Situacao);
        }

        [Test]
        public void AtualizarFuncionarioInexistenteDeveLancarException()
        {
            // Given
            var dto = new FuncionarioPutDTO
            {
                Nome = "Teste",
                Cpf = "99999999999",
                Situacao = Funcionario.SituacaoEnum.A
            };

            // When / Then
            var ex = Assert.ThrowsAsync<Exception>(async () => await _service.Editar(dto, id: 999));
            Assert.That(ex.Message, Is.EqualTo("Usuário não encontrado"));
        }

        [Test]
        public async Task ListarFuncionariosDeveRetornarListaComElementos()
        {
            // Given
            await _context.Funcionarios.AddAsync(new Funcionario
            {
                Nome = "Carlos",
                Cpf = "22222222222",
                Situacao = Funcionario.SituacaoEnum.A,
                DataAlteracao = DateTime.Now
            });
            await _context.SaveChangesAsync();

            // When
            var resultado = await _service.Listar();

            // Then
            Assert.That(resultado, Is.Not.Empty);
            Assert.That(resultado[0].Nome, Is.EqualTo("Carlos"));
        }

        [Test]
        public async Task LerFuncionarioExistenteDeveRetornarFuncionario()
        {
            // Given
            var funcionario = new Funcionario
            {
                Nome = "João",
                Cpf = "33333333333",
                Situacao = Funcionario.SituacaoEnum.A,
                DataAlteracao = DateTime.Now
            };
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();

            // When
            var resultado = await _service.Ler(funcionario.IdFuncionario);

            // Then
            Assert.IsNotNull(resultado);
            Assert.AreEqual("João", resultado.Nome);
        }
    }
}
