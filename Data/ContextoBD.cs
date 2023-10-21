using Microsoft.EntityFrameworkCore;
using Sistema_Odontologico.Models;

namespace Sistema_Odontologico.Data;

public class ContextoBD : DbContext
{
  public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
  {

  }

  //Tabelas
  public DbSet<Paciente> Pacientes { get; set; }
  public DbSet<Medico> Medicos { get; set; }
  public DbSet<Consulta> Consultas { get; set; }
  public DbSet<Procedimento> Procedimentos { get; set; }

}
