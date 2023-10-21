using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Odontologico.Models;

public class Procedimento
{
  [Required]
  public int Id { get; set; }
  [Required]
  [Column(TypeName = "varchar(100)")]
  public string NomeProcedimento { get; set; }
  [Required]
  [Column(TypeName = "varchar(100)")]
  public string DescricaoProcedimento { get; set; }

  public List<Consulta> Consulta { get; set; }


  //propriedade navegação
  public List<Medico> Medico { get; set; }
}
