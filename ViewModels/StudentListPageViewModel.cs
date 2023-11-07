using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteDemoApp.ViewModels;
using SQLiteDemoApp.Views;
using SQLiteDemoApp.Model;
using SQLiteDemoApp.Services;
using System.Collections.ObjectModel;

namespace SQLiteDemoApp.ViewModels
{
    /// <summary>
    /// ViewModel for the page that displays a list of students.
    /// </summary>
    public partial class StudentListPageViewModel : ObservableObject
    {
        // The collection of students that is bound to the view.
        [ObservableProperty]
        private ObservableCollection<StudentModel> _students;

        // A service that handles data operations for student entities.
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentListPageViewModel"/> class.
        /// </summary>
        /// <param name="studentService">The service responsible for student data operations.</param>
        public StudentListPageViewModel(IStudentService studentService)
        {
            // Inject the student service dependency.
            _studentService = studentService;

            // Initialize the collection of students.
            Students = new ObservableCollection<StudentModel>();
        }

        /// <summary>
        /// Initializes the ViewModel by loading the students from the database.
        /// </summary>
        public async Task InitializeAsync()
        {
            // Load the student data.
            await LoadStudents();
        }

        /// <summary>
        /// Loads students from the database and populates the observable collection.
        /// </summary>
        public async Task LoadStudents()
        {
            // Retrieve the list of students from the student service.
            var studentList = await _studentService.GetStudentList();
            if (studentList != null)
            {
                // Clear the existing collection and repopulate it with the new data.
                Students.Clear();
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }

        /// <summary>
        /// Command to navigate to the page for adding a new student.
        /// </summary>
        [RelayCommand]
        public async Task AddStudent()
        {
            // Use Shell navigation to go to the AddUpdateStudentDetail page.
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }

        /// <summary>
        /// Command to delete a student from the database.
        /// </summary>
        /// <param name="student">The student to be deleted.</param>
        [RelayCommand]
        public async Task DeleteStudent(StudentModel student)
        {
            // Delete the student using the student service.
            await _studentService.DeleteStudent(student);
            // Refresh the list to reflect the changes.
            await LoadStudents();
        }
    }
}
