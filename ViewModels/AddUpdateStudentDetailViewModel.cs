﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDemoApp.Views;
using SQLiteDemoApp.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteDemoApp.Services;

namespace SQLiteDemoApp.ViewModels
{
    /// <summary>
    /// ViewModel for adding or updating student details.
    /// </summary>
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        // Observable properties are automatically generated by the CommunityToolkit.Mvvm source generator.
        [ObservableProperty] private string _firstname;
        [ObservableProperty] private string _lastname;
        [ObservableProperty] private string _email;
        [ObservableProperty] private int _studentId;
        [ObservableProperty] private bool isExistingStudent;

        // Reference to the student service to interact with the database.
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddUpdateStudentDetailViewModel"/> class.
        /// </summary>
        /// <param name="studentService">The student service for database operations.</param>
        public AddUpdateStudentDetailViewModel(IStudentService studentService)
        {
            // Inject student service dependency.
            _studentService = studentService;
        }

        /// <summary>
        /// Saves the current student information to the database.
        /// </summary>
        [RelayCommand]
        public async Task SaveStudent()
        {
            // Create a new StudentModel object with the current data.
            var student = new StudentModel
            {
                StudentId = _studentId,
                FirstName = _firstname,
                LastName = _lastname,
                Email = _email
            };

            try
            {
                int result;
                // If StudentId is 0, it's a new student; otherwise, update the existing student.
                if (student.StudentId == 0)
                {
                    result = await _studentService.AddStudent(student);
                }
                else
                {
                    result = await _studentService.UpdateStudent(student);
                }

                // Check the result and log the appropriate message.
                if (result > 0)
                {
                    Console.WriteLine("Student saved successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to save student.");
                }

                // Navigate back to the student list page using shell navigation.
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                // Log the exception if an error occurs during the save operation.
                Console.WriteLine($"Error saving student: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes the current student from the database.
        /// </summary>
        [RelayCommand]
        public async Task DeleteStudent()
        {
            // Create a new StudentModel with the current StudentId.
            var student = new StudentModel
            {
                StudentId = _studentId
            };

            // Call the student service to delete the student.
            await _studentService.DeleteStudent(student);

            // Navigate back to the student list page after deletion.
            await Shell.Current.GoToAsync("..");
        }
    }
}
