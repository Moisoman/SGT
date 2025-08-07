using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Required] public bool Status { get; private set; } = false;
    
    [Required]
    public DateTime DataConsumo { get; set; }
    
    
}