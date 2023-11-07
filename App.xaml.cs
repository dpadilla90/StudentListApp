using SQLiteDemoApp.Services;
using SQLiteDemoApp.ViewModels;
using SQLiteDemoApp.Views;

namespace SQLiteDemoApp
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
