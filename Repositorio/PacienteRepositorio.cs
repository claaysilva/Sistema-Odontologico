using Microsoft.AspNetCore.Mvc;
using Sistema_Odontologico.Data;
using Sistema_Odontologico.DTO.Paciente;
using Sistema_Odontologico.Models;

namespace Sistema_Odontologico.Repositorio;

public class PacienteRepositorio
{
  private ContextoBD _contexto;

  public PacienteRepositorio([FromServices] ContextoBD contexto)
  {
    _contexto = contexto;
  }

  public Paciente CriarPaciente(Paciente paciente)
  {
    _contexto.Pacientes.Add(paciente);
    _contexto.SaveChanges();

    return paciente;
  }

  public List<Paciente> ListarPacientes()
  {
    return _contexto.Pacientes.ToList();
  }


}
