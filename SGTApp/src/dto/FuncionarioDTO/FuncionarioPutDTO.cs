using SGT.entities;
using System.ComponentModel.DataAnnotations;

namespace SGTApp.dto.FuncionarioDTO;
/**
 * DTO para PUT/Edição de um funcionário
 */
public class FuncionarioPutDTO
{
    [Required]
    public long IdFuncionario { get; set; }
    
    public string? Nome { get; set; }
    
    public string? Cpf { get; set; }
    
    public  Funcionario.SituacaoEnum? Situacao { get; set; }
    
    public DateTime? DataAlteracao { get; set; }
}