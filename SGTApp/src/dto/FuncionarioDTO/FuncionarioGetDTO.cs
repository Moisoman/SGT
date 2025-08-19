using System.ComponentModel.DataAnnotations;
using SGT.entities;

namespace SGTApp.dto.FuncionarioDTO;

public class FuncionarioGetDTO
{
    public long IdFuncionario { get; set; }
    
    public string Nome { get; set; }
    
    public string Cpf { get; set; }
    
    public string Situacao { get; set; }

    public DateTime DataAlteracao { get; set; }
    
}