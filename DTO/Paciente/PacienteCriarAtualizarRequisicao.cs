namespace Sistema_Odontologico.DTO.Paciente;

public class PacienteCriarAtualizarRequisicao
{
  public string Nome { get; set; }

  public DateTime DataNascimento { get; set; }

  public string Genero { get; set; }

  public string Endereco { get; set; }

  public string Telefone { get; set; }
  public int Id { get; internal set; }
}
