using Health_Factory.ViewModels;

namespace Health_Factory.Views;

public partial class UsuarioPage : ContentPage
{
	public UsuarioPage(UsuarioViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}