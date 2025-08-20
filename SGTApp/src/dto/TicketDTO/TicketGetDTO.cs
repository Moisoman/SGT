using System.ComponentModel.DataAnnotations;
using SGT.entities;

namespace SGTApp.dto.TicketDTO;
/**
 * DTO para saída de um Ticket
 */
public class TicketGetDTO
{
    [Key]
    public long IdTicket { get; set; }
    
    [Required]
    public long FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    
    [Required]
    public Ticket.TicketEnum Situacao { get; set; }
    
    public string NomeFuncionario { get; set; }
    
    public string CpfFuncionario { get; set; }
    
    public long TotalQuantidade { get; set; }
    
    public List<Ticket> Tickets { get; set; } = new List<Ticket>(); 
}