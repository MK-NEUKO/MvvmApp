using System;
using System.Windows;
using DataAccess;
using Models;

namespace StudentsManager {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private StudentsXmlProvider studentsXmlProvider;

        public MainWindow() {
            InitializeComponent();
        }

        private bool ListHasSelectedItems {
            get { return StudentsList.SelectedItems != null && StudentsList.SelectedItems.Count > 0; }
        }

        protected override void OnInitialized(EventArgs e) {
            base.OnInitialized(e);

            ReloadStudents();
        }

        private void ExitFromApp_OnClick(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void AddStudent_OnClick(object sender, RoutedEventArgs e) {
            var addStudent = new AddEditStudentWindow(studentsXmlProvider);
            addStudent.ShowDialog();

            ReloadStudents();
        }

        private void ReloadStudents() {
            StudentsList.Items.Clear();

            studentsXmlProvider = new StudentsXmlProvider("StudentsRepo.xml");
            var students = studentsXmlProvider.GetAll();

            foreach (var student in students) {
                StudentsList.Items.Add(student);
            }
        }

        private void EditStudent_OnClick(object sender, RoutedEventArgs e) {
            if (ListHasSelectedItems) {
                var student = StudentsList.SelectedItems[0] as Student;
                var addStudent = new AddEditStudentWindow(student, studentsXmlProvider);
                addStudent.ShowDialog();

                ReloadStudents();
            }
        }

        private void RemoveStudent_OnClick(object sender, RoutedEventArgs e) {
            if (ListHasSelectedItems) {
                var item = StudentsList.SelectedItems?[0] as Student;
                studentsXmlProvider.Remove(item.Id);
                RemoveFromListBox(item);
            }
        }

        private void RemoveFromListBox(Student item) {
            StudentsList.Items.Remove(item);
        }

        private void SubmitChanges_OnClick(object sender, RoutedEventArgs e) {
            try {
                studentsXmlProvider.SubmitChanges();
            }
            catch (Exception ex) {                
            }
        }
    }
}