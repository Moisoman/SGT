using System.ComponentModel.DataAnnotations;

namespace SGT.entities;

/**
 * Entidade que representa o funcionario no sistema
 */
public class Funcionario
{
    [Key]
    public long IdFuncionario { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Cpf { get; set; }

    [Required]
    public SituacaoEnum Situacao { get; set; }

    public DateTime DataAlteracao { get; set; }

    public ICollection<Ticket> Tickets { get; set; }
    
    public enum SituacaoEnum
    {
        A,I
    }
    
}