using Health_Factory.Views;

namespace Health_Factory
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
    }
}
