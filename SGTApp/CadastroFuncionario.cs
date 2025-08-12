using System.Windows.Forms.VisualStyles;
using Microsoft.EntityFrameworkCore;
using SGT.entities;
using SGTApp.controllers;
using SGTApp.data;
using SGTApp.dto.FuncionarioDTO;
using SGTApp.services;

namespace SGTApp;

public partial class CadastroFuncionario : Form
{
    private FuncionarioController _funcionarioController;
    private ApplicationContext _context;

    public CadastroFuncionario()
    {
        InitializeComponent();
    
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=sgtAppDb.db")
            .Options;
        
        var contextDb = new AppDbContext(options);
        var service = new FuncionarioService(contextDb);
        _funcionarioController = new FuncionarioController(service);
    }

    private async void sendButton_Click(object sender, EventArgs e)
    {
        
        Funcionario funcionario = new Funcionario();
        funcionario.Cpf = cpfBox.Text;
        funcionario.Nome = nomeBox.Text;
        funcionario.Situacao = Funcionario.SituacaoEnum.A;
        funcionario.DataAlteracao = DateTime.Now;
        
        await _context.Funcionarios.AddAsync(funcionario);
        _context.SaveChanges();
        try
        {
            await _funcionarioController.Cadastrar(dto);
            MessageBox.Show("Cadastro efetuado com sucesso");  
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.ToString());
            throw;
        }
    }
}