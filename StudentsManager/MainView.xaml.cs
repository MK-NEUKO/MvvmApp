using System;
using System.Windows;
using DataAccess;
using StudentsManager.ViewModels;

//using DataAccess;
//using Models;

namespace StudentsManager {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window {
        public MainView() {
            InitializeComponent();
            DataContext = new MainViewModel(new StudentsXmlProvider("StudentsRepo.xml"));
        }

        private void ExitFromApp_OnClick(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void AddStudent_OnClick(object sender, RoutedEventArgs e) {
        }

        private void EditStudent_OnClick(object sender, RoutedEventArgs e) {
        }

        private void RemoveStudent_OnClick(object sender, RoutedEventArgs e) {

        }

        private void SubmitChanges_OnClick(object sender, RoutedEventArgs e) {

        }
    }
}