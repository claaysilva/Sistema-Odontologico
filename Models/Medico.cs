using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Odontologico.Models;

public class Medico
{
  [Required]
  public int Id { get; set; }
  [Required]
  [Column(TypeName = "varchar(100)")]
  public string Nome { get; set; }
  [Required]
  public string Especialidade { get; set; }
  [Required]
  public int HoraAtendimento { get; set; }

  //propriedade navegação
  public List<Consulta> Consulta { get; set; }

  //propriedade navegação
  public List<Procedimento> Procedimento { get; set; }

}
