using System.ComponentModel.DataAnnotations;
using SGT.entities;

namespace SGTApp.dto.TicketDTO;
/**
 * DTO para Cadastro/POST de um ticket
 */
public class TicketPostDTO
{
    [Required]
    public long FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    
}