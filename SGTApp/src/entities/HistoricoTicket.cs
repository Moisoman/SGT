using System.ComponentModel.DataAnnotations;

namespace SGT.entities;

/**
 * Entidade que grava o Historico de movimentação dos Tickets no sistema
 */
public class HistoricoTicket
{
    [Key]
    public long IdHistorico { get; set; }
    
    [Required]
    public long TicketId { get; set; }
    public Ticket Ticket { get; set; }
    
    [Required]
    public long FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }

    [Required] 
    public bool StatusConsumo { get; private set; } = true;
    
    [Required]
    public DateTime DataConsumo { get; set; }
    
    
}