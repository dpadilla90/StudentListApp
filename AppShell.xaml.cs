using SQLiteDemoApp.Views;

namespace SQLiteDemoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StudentListPage), typeof(StudentListPage));

            Routing.RegisterRoute(nameof(AddUpdateStudentDetail), typeof(AddUpdateStudentDetail));
        }
    }
}