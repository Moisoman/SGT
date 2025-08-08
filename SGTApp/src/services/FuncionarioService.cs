using Microsoft.EntityFrameworkCore;
using SGT.entities;
using SGTApp.data;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.utils;

namespace SGTApp.services;


public class FuncionarioService 
{
    private readonly AppDbContext _context;

    public FuncionarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Funcionario>> Listar()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    public async Task<Funcionario> Ler(long id)
    {
        return await _context.Funcionarios.FindAsync(id);
    }
    
    public async Task<Funcionario> Casdatrar(FuncionarioPostDTO dto)
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(dto.Cpf))
        {
            erros.Add("Cpf inserido é invalido");
        }

        if (string.IsNullOrWhiteSpace(dto.Nome))
        {
            erros.Add("Nome inserido é invalido");
        }

        if (erros.Count > 0)
        {
            throw new ValidationException(erros);
        }
        
        Funcionario funcionario = new Funcionario();
        funcionario.Cpf = dto.Cpf;
        funcionario.Nome = dto.Nome;
        funcionario.Situacao = Funcionario.SituacaoEnum.A;
        funcionario.DataAlteracao = DateTime.Now;
        
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();

        return funcionario;
    }

    public async Task<Funcionario> Editar(FuncionarioPutDTO dto, long id)
    {
        List<string> erros = new List<string>();

        var funcionarioExistente = await _context.FindAsync<Funcionario>(id);

        if (funcionarioExistente == null)
        {
            throw new Exception("Usuário não encontrado");
        }
        
        if (dto.Cpf != null)
        {
            if (string.IsNullOrWhiteSpace(dto.Cpf))
                erros.Add("CPF inserido é inválido");
            else
                funcionarioExistente.Cpf = dto.Cpf;
        }

        if (dto.Nome != null)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                erros.Add("Nome inserido é inválido");
            else
                funcionarioExistente.Nome = dto.Nome;
        }

        if (dto.Situacao != null)
        {
            funcionarioExistente.Situacao = dto.Situacao.Value;
        }

        if (erros.Count > 0)
        {
            throw new ValidationException(erros);
        }
        
        funcionarioExistente.DataAlteracao = DateTime.Now;
        
        await _context.SaveChangesAsync();
        
        return funcionarioExistente;
    }
}