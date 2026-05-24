using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using AgendamentoVeterinario.Cadastro.API.Infrastructure.Repositories;
using AgendamentoVeterinario.Cadastro.API.Application.UseCases;
using DataApplication.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AgendamentoVeterinarioContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("StringConn"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("StringConn"))
    ));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<RegistrarUsuarioUseCase>();
builder.Services.AddScoped<CadastrarPetUseCase>();
builder.Services.AddScoped<ExcluirPetUseCase>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AgendamentoVeterinarioContext>();
        InitializeContext.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();