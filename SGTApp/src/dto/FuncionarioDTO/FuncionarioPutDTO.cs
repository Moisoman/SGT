using SGT.entities;
using System.ComponentModel.DataAnnotations;

namespace SGTApp.dto.FuncionarioDTO;

public class FuncionarioPutDTO
{
    [Required]
    public long IdFuncionario { get; set; }
    
    public string? Nome { get; set; }
    
    public string? Cpf { get; set; }
    
    public  Funcionario.SituacaoEnum? Situacao { get; set; }
}