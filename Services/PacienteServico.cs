using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
    var pacienteResposta = ConverterModeloParaResposta(paciente);

    //Retornando resposta para o controlador
    return pacienteResposta;

  }

  public List<PacienteResposta> ListarPacientes()
  {

    //Pedir ao repositorio todos os procedimentos (modelo)
    var pacientes = _pacienteRepositorio.ListarPacientes();

    //copiar os dados dos modelos para as respostas
    List<PacienteResposta> pacienteRespostas = new(); //lista vazia de respostas

    foreach (var paciente in pacientes)
    {
      //Copiando do modelo para a resposta
      var pacienteResposta = ConverterModeloParaResposta(paciente);

      //Adicionar na lista de respostas
      pacienteRespostas.Add(pacienteResposta);
    }

    //retornar a lista de respostas
    return pacienteRespostas;

  }

  public PacienteResposta BuscarPacientePeloId(int id)
  {
    var paciente = _pacienteRepositorio.BuscarPacientePeloId(id);

    if (paciente is null)
    {
      return null;
    }

    var pacienteResposta = ConverterModeloParaResposta(paciente);

    return pacienteResposta;
  }

  public void RemoverPaciente(int id)
  {
    var paciente = _pacienteRepositorio.BuscarPacientePeloId(id);

    if (paciente is null)
    {
      return;
    }

    _pacienteRepositorio.RemoverPaciente(paciente);

  }

  public PacienteResposta AtualizarProcedimento(int id, PacienteCriarAtualizarRequisicao pacienteEditado)
  {
    var paciente = _pacienteRepositorio.BuscarPacientePeloId(id);

    if (paciente is null)
    {
      return null;
    }

    paciente.Nome = pacienteEditado.Nome;
    paciente.DataNascimento = pacienteEditado.DataNascimento;
    paciente.Genero = pacienteEditado.Genero;
    paciente.Endereco = pacienteEditado.Endereco;
    paciente.Telefone = pacienteEditado.Telefone;

    _pacienteRepositorio.AtualizarPaciente();

    var pacienteResposta = ConverterModeloParaResposta(paciente);

    return pacienteResposta;
  }

  private PacienteResposta ConverterModeloParaResposta(Paciente modelo)
  {
    var pacienteResposta = new PacienteResposta();
    pacienteResposta.Id = modelo.Id;
    pacienteResposta.Nome = modelo.Nome;
    pacienteResposta.DataNascimento = modelo.DataNascimento;
    pacienteResposta.Genero = modelo.Genero;
    pacienteResposta.Endereco = modelo.Endereco;
    pacienteResposta.Telefone = modelo.Telefone;

    return pacienteResposta;
  }

}
