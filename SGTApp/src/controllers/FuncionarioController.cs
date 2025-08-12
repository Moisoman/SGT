using SGT.entities;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.services;

namespace SGTApp.controllers;

public class FuncionarioController
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionarioController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    public async Task<List<Funcionario>> Listar()
    {
        return await _funcionarioService.Listar();
    }

    public async Task<Funcionario> Ler(long id)
    {
        return await _funcionarioService.Ler(id);
    }

    public async Task<Funcionario> Cadastrar(FuncionarioPostDTO funcionario)
    {
        return await _funcionarioService.Cadastrar(funcionario);
    }

    public async Task<Funcionario> Editar(FuncionarioPutDTO funcionario,long id)
    {
        return await _funcionarioService.Editar(funcionario, id);
    }
}