using Health_Factory.Views;

namespace Health_Factory
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(UsuarioPage), typeof(UsuarioPage));
            Routing.RegisterRoute(nameof(IniciarSesionPage), typeof(IniciarSesionPage));
            Routing.RegisterRoute(nameof(InicioPage), typeof(InicioPage));
        }
    }
}
