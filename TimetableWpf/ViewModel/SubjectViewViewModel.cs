using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimetableWpf
{
    public class SubjectViewViewModel : ViewModelBase
    {
        private string name;
        private Subject selectedSubject;
        public ObservableCollection<Subject> subjects;

        public string Name { get { return name; } set { name = value; RaisePropertyChanged("Name"); } }
        public Subject SelectedSubject { get { return selectedSubject; } set { selectedSubject = value; RaisePropertyChanged("SelectedSubject"); } }
        public ObservableCollection<Subject> Subjects { get { return subjects; } set { subjects = value; RaisePropertyChanged("Subjects"); } }

        public RelayCommand AddSubject { get; private set; }
        public RelayCommand ChangeSubject { get; private set; }

        public Visibility IsEnabledAdd { get; set; }
        public Visibility IsEnabledChange { get; set; }

        public SubjectViewViewModel(ObservableCollection<Subject> subjects)
        {
            Subjects = subjects;
            IsEnabledChange = Visibility.Hidden;
            IsEnabledAdd = Visibility.Visible;
            AddSubject = new RelayCommand(AddSubject_Execute);
        }

        public SubjectViewViewModel(Subject selectedSubject)
        {
            Name = selectedSubject.Name;
            SelectedSubject = selectedSubject;
            IsEnabledAdd = Visibility.Hidden;
            IsEnabledChange = Visibility.Visible;
            ChangeSubject = new RelayCommand(ChangeSubject_Execute, ChangeSubject_CanExecute);
        }

        public void AddSubject_Execute()
        {
            Subjects.Add(new Subject(Name));
        }

        private void ChangeSubject_Execute()
        {
            SelectedSubject.Name = Name;
        }

        private bool ChangeSubject_CanExecute()
        {
            return true;
        }
    }
}
