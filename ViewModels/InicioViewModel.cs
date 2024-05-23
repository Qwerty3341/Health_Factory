using CommunityToolkit.Mvvm.Input;
using Health_Factory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_Factory.ViewModels
{
    public partial class InicioViewModel
    {
        [RelayCommand]
        private async Task NavegarARegistros()
        {
            await Shell.Current.GoToAsync(nameof(UsuarioPage));
        }

        [RelayCommand]
        private async Task NavegarAIniciarSesion()
        {
            // Supongamos que tienes una página llamada IniciarSesionPage
            await Shell.Current.GoToAsync(nameof(IniciarSesionPage));
        }
    }
}
