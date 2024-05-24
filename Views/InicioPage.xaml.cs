using Health_Factory.ViewModels;

namespace Health_Factory.Views
{
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
            BindingContext = new InicioPageViewModel();
        }

        private async void OnAccederClicked(object sender, EventArgs e)
        {
            string nombre = NombreEntry.Text;
            string apellido = ApellidoEntry.Text;

            if (nombre.Trim() == "admin" && apellido.Trim() == "admin") 
            {
                await Shell.Current.GoToAsync("//MainPage");
            }
            else
            {
                //await DisplayAlert("Acceso", $"Hola {nombre} {apellido}", "OK");
            }

        }

        private async void OnLabelClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Registro", "Navegando a la p�gina de registro", "OK");
            // Por ejemplo, para navegar a una p�gina llamada RegistroPage:
            // await Shell.Current.GoToAsync("RegistroPage");
        }
    }
}
