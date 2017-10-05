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
            }
        }
        public RelayCommand OpenMessageBox { get; private set; }
        public RelayCommand OpenAddDialog { get; private set; }
        public RelayCommand OpenChangeDialog { get; private set; }
        #endregion

        #region Constructor
        public DataViewViewModel()
        {
            Subjects = new ObservableCollection<Subject>()
            {
                new Subject("Математика", 5, 1),
                new Subject("Русский язык", 6, 2),
                new Subject("Физика", 4, 2),
            };
            OpenAddDialog = new RelayCommand(OpenAddDialog_Execute);
            OpenMessageBox = new RelayCommand(OpenMessageBox_Execute);
            OpenChangeDialog = new RelayCommand(OpenChangeDialog_Execute, OpenChangeDialog_CanExecute);
        }
        #endregion

        #region Commands
        private void OpenMessageBox_Execute()
        {
            MessageBox.Show("asdfda");
        }
        private void OpenAddDialog_Execute()
        {
            View = new SubjectView();
            View.ShowView(new SubjectViewViewModel(Subjects));
        }
        private void OpenChangeDialog_Execute()
        {
            View = new SubjectView();
            View.ShowView(new SubjectViewViewModel(SelectedSubject));
        }
        private bool OpenChangeDialog_CanExecute()
        {
            return SelectedSubject != null;
        }
        #endregion
    }
}
