using System.ComponentModel.DataAnnotations;
using SGT.entities;

namespace SGTApp.dto.TicketDTO;
/**
 * DTO para atualização/PUT de um Ticket
 */
public class TicketPutDTO
{
    [Required]
    public long FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    
    [Required]
    public long Quantidade { get; set; }
    
    [Required]
    public Ticket.TicketEnum? Situacao { get; set; }
}