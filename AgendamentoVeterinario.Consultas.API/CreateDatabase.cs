using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataApplication.Context;

namespace AgendamentoVeterinario.Consultas.API
{
    public class CreateDatabase
    {
        public IConfiguration configRoot { get; }

        public CreateDatabase(IConfiguration configuration)
        {
            configRoot = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AgendamentoVeterinarioContext>();

            try
            {
                context.Database.EnsureCreated();
            }
            catch (Exception)
            {
            }
        }
    }
}