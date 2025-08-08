using System.ComponentModel.DataAnnotations;

namespace SGTApp.dto.FuncionarioDTO;

public class FuncionarioPostDTO
{
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Cpf { get; set; }
}