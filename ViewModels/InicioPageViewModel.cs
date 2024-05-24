using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Health_Factory.Views;

namespace Health_Factory.ViewModels
{
    public partial class InicioPageViewModel : ObservableObject
    {

        [RelayCommand]
        private async Task IrAUsuario()
        {
            var uri = $"{nameof(UsuarioPage)}?id=0";
            await Shell.Current.GoToAsync(uri);
        }

    }
}
