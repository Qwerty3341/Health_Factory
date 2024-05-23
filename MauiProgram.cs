using Microsoft.Extensions.Logging;
using Health_Factory.DataAccess;
using Health_Factory.ViewModels;
using Health_Factory.Views;

namespace Health_Factory
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Code

            var dbContext = new UsuarioDbContext(); //Crear contexto de la base de datos
            dbContext.Database.EnsureCreated(); // Asegurarse de que sea creada
            dbContext.Dispose();//Liberar base de datos


            builder.Services.AddDbContext<UsuarioDbContext>();//hacer instancia de base de datos

            builder.Services.AddTransient<UsuarioPage>();
            builder.Services.AddTransient<UsuarioViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();

            Routing.RegisterRoute(nameof(UsuarioPage), typeof(UsuarioPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
