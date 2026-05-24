using DataApplication.Context;

namespace AgendamentoVeterinario.Consultas.API
{
    public class CreateDatabase
    {
        public IConfiguration configRoot
        {
            get;
        }
        public CreateDatabase(IConfiguration configuration)
        {
            configRoot = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<AgendamentoVeterinarioContext>();

            context.Database.EnsureCreated();
        }
    }
}
