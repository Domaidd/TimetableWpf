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
        private int hoursPerWeek;
        private int hoursPerDay;
        private Subject selectedSubject;

        public string Name { get { return name; } set { name = value; } }
        public int HoursPerWeek { get { return hoursPerWeek; } set { hoursPerWeek = value; } }
        public int HoursPerDay { get { return hoursPerDay; } set { hoursPerDay = value; } }
        public Subject SelectedSubject { get { return selectedSubject; } set { selectedSubject = value; } }

        public ObservableCollection<Subject> Subjects { get; set; }

        public RelayCommand AddSubject { get; private set; }
        public RelayCommand ChangeSubject { get; private set; }

        public Visibility IsEnabledAdd { get; set; }
        public Visibility IsEnabledChange { get; set; }

        public SubjectViewViewModel(ObservableCollection<Subject> Subjects)
        {
            this.Subjects = Subjects;
            IsEnabledChange = Visibility.Hidden;
            IsEnabledAdd = Visibility.Visible;
            AddSubject = new RelayCommand(AddSubject_Execute);
        }

        public SubjectViewViewModel(Subject selectedSubject)
        {
            Name = selectedSubject.Name;
            HoursPerDay = selectedSubject.HoursPerDay;
            HoursPerWeek = selectedSubject.HoursPerWeek;
            SelectedSubject = selectedSubject;
            IsEnabledAdd = Visibility.Hidden;
            IsEnabledChange = Visibility.Visible;
            ChangeSubject = new RelayCommand(ChangeSubject_Execute);
        }

        public void AddSubject_Execute()
        {
            Subjects.Add(new Subject(Name, HoursPerWeek, HoursPerDay));
        }

        private void ChangeSubject_Execute()
        {
            SelectedSubject.Name = Name;
            SelectedSubject.HoursPerDay = HoursPerDay;
            SelectedSubject.HoursPerWeek = hoursPerWeek;
        }
    }
}
