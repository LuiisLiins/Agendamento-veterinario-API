namespace DataApplication.Context
{
    public class InitializeContext
    {
        public static void Initialize(AgendamentoVeterinarioContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
