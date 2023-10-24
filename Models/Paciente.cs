using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Odontologico.Models;

public class Paciente
{
  [Required]
  public int Id { get; set; }
  [Required]
  [Column(TypeName = "varchar(100)")]
  public string Nome { get; set; }
  [Required]
  public DateTime DataNascimento { get; set; }
  [Required]
  public string Genero { get; set; }
  [Required]
  [Column(TypeName = "varchar(100)")]
  public string Endereco { get; set; }
  [Required]
  [Column(TypeName = "varchar(20)")]
  public string Telefone { get; set; }


  // //propriedade navegação
  // public Consulta Consulta { get; set; }

  //propriedade navegação
  public List<Consulta> Consulta { get; set; }

}
