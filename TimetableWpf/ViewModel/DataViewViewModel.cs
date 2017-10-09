using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace TimetableWpf
{
    public class DataViewViewModel : ViewModelBase
    {

        #region Fields
        private ObservableCollection<Subject> subjects;
        private Subject selectedSubject;
        #endregion

        #region Properties
        public IView View { get; set; }
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set
            {
                subjects = value;
                RaisePropertyChanged("Subjects");
            }
        }
        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                RaisePropertyChanged("SelectedSubject");
                OpenChangeDialog.RaiseCanExecuteChanged();
                RemoveSubject.RaiseCanExecuteChanged();
            }
        }
        public RelayCommand OpenAddDialog { get; private set; }
        public RelayCommand OpenChangeDialog { get; private set; }
        public RelayCommand RemoveSubject { get; private set; }
        #endregion

        #region Constructor
        public DataViewViewModel()
        {
            Subjects = DataManager.Load<ObservableCollection<Subject>>("Subjects.xml");
            OpenAddDialog = new RelayCommand(OpenAddDialog_Execute);
            OpenChangeDialog = new RelayCommand(OpenChangeDialog_Execute, () => { return SelectedSubject != null; });
            RemoveSubject = new RelayCommand(RemoveSubject_Execute, () => { return SelectedSubject != null; });
        }
        #endregion

        #region Commands
        private void OpenAddDialog_Execute()
        {
            View = new SubjectView();
            View.Window.Closing += UpdateAdd;
            View.ShowView(new SubjectViewViewModel(Subjects));
        }

        private void UpdateAdd(object sender, CancelEventArgs e)
        {
            Disponse();
        }

        private void OpenChangeDialog_Execute()
        {
            View = new SubjectView();
            View.Window.Closing += UpdateChange;
            View.ShowView(new SubjectViewViewModel(SelectedSubject));
        }

        private void UpdateChange(object sender, CancelEventArgs e)
        {
            List<Subject> collection = new List<Subject>();
            foreach (var item in Subjects)
            {
                collection.Add(item);
            }
            Subjects.Clear();
            foreach (var item in collection)
            {
                Subjects.Add(item);
            }
            Disponse();
        }

        private void RemoveSubject_Execute()
        {
            foreach (var item in Subjects)
            {
                if (item == selectedSubject)
                {
                    Subjects.Remove(selectedSubject);
                    Disponse();
                    break;
                }
            }
        }

        private void Disponse()
        {
            DataManager.Save(Subjects, "Subjects.xml");
        }
        #endregion
    }
}
