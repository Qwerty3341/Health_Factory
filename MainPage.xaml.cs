using Health_Factory.ViewModels;

namespace Health_Factory
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }


    }

}
