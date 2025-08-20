using System.ComponentModel.DataAnnotations;

namespace SGTApp.dto.FuncionarioDTO;
/**
 * DTO para Metodo Post/Cadastro de um funcionario
 */
public class FuncionarioPostDTO
{
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Cpf { get; set; }
}