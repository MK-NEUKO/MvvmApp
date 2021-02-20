using System.Collections.ObjectModel;
using DataAccess;
using Models;

namespace StudentsManager.ViewModels 
{
    public class MainViewModel 
    {
        private IDataProvider<Student> studentsXmlProvider;
        public ObservableCollection<Student> Students { get; private set; }

        public MainViewModel(IDataProvider<Student> provider) 
        {
            studentsXmlProvider = provider;
            ReloadStudents();
        }

        private void ReloadStudents() 
        {            
            var students = studentsXmlProvider.GetAll();
            Students = new ObservableCollection<Student>(students);
        }
    }
}