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
    public long FuncionarioId { get; set; }
    public Funcionario Funcionario { get; set; }
    
    [Required]
    public long Quantidade { get; set; }
    
    [Required]
    public TicketEnum Situacao { get; set; }

    public enum TicketEnum
    {
        A,I
    }
    
    [Required]
    public DateTime DataEntrega { get; private set; } = DateTime.Now;

    /**
     * Metodo para validar a criação de um registro, para que a situação não seja por padrão Inativa
     * 
     */
    public void validarCriacao()
    {
        if (Situacao == TicketEnum.I)
        {
            throw new ValidationException("Não é permitido criar um registro Inativo");
        }
    }
    
}