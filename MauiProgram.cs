﻿using Microsoft.Extensions.Logging;
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

            // Crear contexto de la base de datos
            var dbContext = new UsuarioDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

            // Registrar servicios
            builder.Services.AddDbContext<UsuarioDbContext>();
            builder.Services.AddTransient<UsuarioViewModel>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<InicioPageViewModel>();

            builder.Services.AddTransient<UsuarioPage>(sp =>
            {
                var viewModel = sp.GetRequiredService<UsuarioViewModel>();
                return new UsuarioPage(viewModel);
            });
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<InicioPage>();

            // Registrar rutas
            Routing.RegisterRoute(nameof(UsuarioPage), typeof(UsuarioPage));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
