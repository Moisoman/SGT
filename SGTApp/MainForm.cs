namespace SGTApp;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        var cadastroTicketForm = new CadastroTicket();
        cadastroTicketForm.ShowDialog();
    }


    private void button3_Click(object sender, EventArgs e)
    {
        var atualizarFuncionarioForm = new AtualizarFuncionario();
        atualizarFuncionarioForm.ShowDialog();
    }
}