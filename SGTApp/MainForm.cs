using Microsoft.EntityFrameworkCore;
using SGTApp.data;

namespace SGTApp;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        
    }
    
    private void CadastrarTicket_Click(object sender, EventArgs e)
    {
        var cadastroTicketForm = new CadastroTicket();
        cadastroTicketForm.ShowDialog();
    }


    private void AtualizarFuncionario_Click(object sender, EventArgs e)
    {
        var atualizarFuncionarioForm = new AtualizarFuncionario();
        atualizarFuncionarioForm.ShowDialog();
    }

    private void CadastrarFuncionario_Click(object sender, EventArgs e)
    {
        var cadastroFuncionarioForm = new CadastroFuncionario();
        cadastroFuncionarioForm.ShowDialog();
    }

    private void AtualizarTicket_Click(object sender, EventArgs e)
    {
        
    }
}