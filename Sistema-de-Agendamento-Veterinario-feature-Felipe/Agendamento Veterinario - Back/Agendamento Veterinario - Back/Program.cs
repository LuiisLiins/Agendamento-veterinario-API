using Agendamento_Veterinario___Back.Domain.Repositories;
using Agendamento_Veterinario___Back.Domain.Services;
using Agendamento_Veterinario___Back.Repositories;
using Agendamento_Veterinario___Back.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Agendamento_Veterinario___Back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IPetService, PetService>();
            builder.Services.AddScoped<IVeterinarioService, VeterinarioService>();
            builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "");
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
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

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

