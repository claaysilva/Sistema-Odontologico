using System.ComponentModel.DataAnnotations;

namespace Sistema_Odontologico.Models;

public class Consulta
{
  [Required]
  public int Id { get; set; }
  [Required]
  public DateTime DataHora { get; set; }

  //chave estrangeira para tabela Paciente 1:1
  //public int PacienteId { get; set; }

  //propriedade navegação
  public Paciente Paciente { get; set; }

  //chave estrangeira para procedimento 1:N
  public int PacienteId { get; set; }

  //propriedade navegação
  public Medico Medico { get; set; }

  //chave estrangeira para procedimento 1:N
  public int MedicoId { get; set; }

  //propriedade navegação
  public Procedimento Procedimento { get; set; }

  //chave estrangeira para procedimento 1:N
  public int ProcedimentoId { get; set; }
}
