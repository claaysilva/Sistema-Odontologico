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
}
