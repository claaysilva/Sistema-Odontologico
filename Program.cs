using Microsoft.EntityFrameworkCore;
using Sistema_Odontologico.Data;
using Sistema_Odontologico.Repositorio;
using Sistema_Odontologico.Services;

var builder = WebApplication.CreateBuilder(args);

//Adicionando a minha classe de contexto na API
//Tem que acrescentar using Microsoft.EntityFrameworkCore;
builder.Services.AddDbContext<ContextoBD>(
  options =>
  //Dizendo que vamos usar o MySQL
  options.UseMySql(
      //Pegando as configurações de acesso ao BD
      builder.Configuration.GetConnectionString("ConexaoBanco"),
      //Detectando o Servidor de BD
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
  )
);


// Add services to the container.
builder.Services.AddScoped<PacienteServico>();
builder.Services.AddScoped<PacienteRepositorio>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
