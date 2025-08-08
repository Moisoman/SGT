using Microsoft.EntityFrameworkCore;
using SGTApp.data;
using SGTApp.services;

namespace SGTApp;

public partial class CadastroFuncionario : Form
{
    private readonly FuncionarioService _funcionarioService;   
    public CadastroFuncionario()
    {
        InitializeComponent();
        
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=sgt.db") 
            .Options;

        var context = new AppDbContext(options);
        context.Database.EnsureCreated();
        
        _funcionarioService = new FuncionarioService(context);
    }
}