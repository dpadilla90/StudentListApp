using SQLiteDemoApp.ViewModels;

namespace SQLiteDemoApp.Views
{
    /// <summary>
    /// The page that displays the list of students.
    /// </summary>
    public partial class StudentListPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentListPage"/> content page class.
        /// </summary>
        /// <param name="viewModel">The ViewModel that provides the student data and behavior for the page.</param>
        public StudentListPage(StudentListPageViewModel viewModel)
        {
            // Initializes the page's components (defined in XAML)
            InitializeComponent();

            // Sets the ViewModel as the BindingContext to enable data binding
            BindingContext = viewModel;
        }

        /// <summary>
        /// Called when the page is about to appear.
        /// </summary>
        protected override async void OnAppearing()
        {
            // Call the base class implementation
            base.OnAppearing();

            // Attempt to cast the BindingContext back to the specific ViewModel type
            var viewModel = this.BindingContext as StudentListPageViewModel;

            // If the cast is successful, call the method to load students
            if (viewModel != null)
            {
                // Load the list of students from the ViewModel
                await viewModel.LoadStudents();
            }
        }
    }
}