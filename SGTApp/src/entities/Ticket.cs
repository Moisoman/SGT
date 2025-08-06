using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SGT.entities;

/**
 *  Entidade que representa o Ticket do sistema
 */
public class Ticket
{
    [Key]
    public long IdTicket { get; set; }
    
    [Required]
    [ForeignKey("Funcionario")]
    public long FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    
    [Required]
    public long Quantidade { get; set; }
    
    [Required]
    public SituacaoEnum Situacao { get; set; }

    public enum SituacaoEnum
    {
        A,I
    }
    
    [Required]
    public DateTime DataEntrega { get; set; }
    
    
}