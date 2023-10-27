using Microsoft.AspNetCore.Mvc;
using Sistema_Odontologico.DTO.Paciente;
using Sistema_Odontologico.Services;

namespace Sistema_Odontologico.Controllers;

[ApiController]
[Route("Paciente")]
public class PacienteController : ControllerBase
{
  private PacienteServico _pacienteServico;

  public PacienteController([FromServices] PacienteServico servico)
  {
    _pacienteServico = servico;
  }


  [HttpPost]
  public PacienteResposta PostPaciente([FromBody] PacienteCriarAtualizarRequisicao novoPaciente)
  {
    var pacienteResposta = _pacienteServico.CriarPaciente(novoPaciente);

    return pacienteResposta;
  }

  [HttpGet]
  public List<PacienteResposta> GetPacientes()
  {
    return _pacienteServico.ListarPacientes();
  }

  [HttpGet("{id:int}")]
  public PacienteResposta GetPaciente([FromRoute] int id)
  {
    return _pacienteServico.BuscarPacientePeloId(id);
  }

  [HttpDelete("{id:int}")]
  public void DeletePaciente([FromRoute] int id)
  {
    _pacienteServico.RemoverPaciente(id);
  }

  [HttpPut("{id:int}")]
  public PacienteResposta PutPaciente([FromRoute] int id, [FromBody] PacienteCriarAtualizarRequisicao pacienteEditado)
  {
    var pacienteResposta = _pacienteServico.AtualizarProcedimento(id, pacienteEditado);

    return pacienteResposta;
  }
}
