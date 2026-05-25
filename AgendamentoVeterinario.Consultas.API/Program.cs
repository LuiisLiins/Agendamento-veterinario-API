using AgendamentoVeterinario.Consultas.API.Domain.Repositories;
using AgendamentoVeterinario.Consultas.API.Infrastructure.Repositories;
using AgendamentoVeterinario.Consultas.API.Application.UseCases;
using DataApplication.Context;
using Microsoft.EntityFrameworkCore;
using AgendamentoVeterinario.Consultas.API;

var builder = WebApplication.CreateBuilder(args);
var startup = new CreateDatabase(builder.Configuration);

builder.Services.AddDbContext<AgendamentoVeterinarioContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("StringConn"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("StringConn"))
    ));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 👇 Repositórios e UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // AQUI ESTÁ A CORREÇÃO!
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();

// 👇 Casos de Uso
builder.Services.AddScoped<AgendarConsultaUseCase>();

var app = builder.Build();

startup.Configure(app, builder.Environment);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();