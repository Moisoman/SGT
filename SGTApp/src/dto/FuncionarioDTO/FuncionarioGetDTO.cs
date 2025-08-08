using System.ComponentModel.DataAnnotations;
using SGT.entities;

namespace SGTApp.dto.FuncionarioDTO;

public class FuncionarioGetDTO
{
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Cpf { get; set; }

    [Required]
    public string Situacao { get; set; }

    public DateTime DataAlteracao { get; set; }
    
}