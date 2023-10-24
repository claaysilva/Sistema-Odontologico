using Microsoft.AspNetCore.Mvc;
using Sistema_Odontologico.DTO.Paciente;
using Sistema_Odontologico.Models;
using Sistema_Odontologico.Repositorio;

namespace Sistema_Odontologico.Services;

public class PacienteServico
{
  private PacienteRepositorio _pacienteRepositorio;

  public PacienteServico([FromServices] PacienteRepositorio repositorio)
  {
    _pacienteRepositorio = repositorio;
  }

  public PacienteResposta CriarPaciente(PacienteCriarAtualizarRequisicao novoPaciente)
  {
    //copiar o dados da requisição para modelo
    Paciente paciente = new();
    paciente.Nome = novoPaciente.Nome;
    paciente.DataNascimento = novoPaciente.DataNascimento;
    paciente.Genero = novoPaciente.Genero;
    paciente.Endereco = novoPaciente.Endereco;
    paciente.Telefone = novoPaciente.Telefone;

    //Regra Especifica
    //aqui.....


    //mandando o repositorio salvar o modelo no BD
    paciente = _pacienteRepositorio.CriarPaciente(paciente);

    //copiando os dados do modelo para a resposta
    var pacienteResposta = new PacienteResposta();
    paciente.Id = novoPaciente.Id;
    paciente.Nome = novoPaciente.Nome;
    paciente.DataNascimento = novoPaciente.DataNascimento;
    paciente.Genero = novoPaciente.Genero;
    paciente.Endereco = novoPaciente.Endereco;
    paciente.Telefone = novoPaciente.Telefone;

    //Retornando resposta para o controlador
    return pacienteResposta;

  }
}
