using SQLiteDemoApp.ViewModels;


namespace SQLiteDemoApp.Views
{
    /// <summary>
    /// Represents the content page for adding or updating student details.
    /// </summary>
    public partial class AddUpdateStudentDetail : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddUpdateStudentDetail"/> content page class.
        /// </summary>
        /// <param name="viewModel">The ViewModel that contains the logic for adding or updating student details.</param>
        public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
        {
            // Initializes the page's components (defined in XAML)
            InitializeComponent();

            // Sets the ViewModel as the BindingContext of the page to enable data binding between the View and ViewModel
            this.BindingContext = viewModel;
        }
    }
}