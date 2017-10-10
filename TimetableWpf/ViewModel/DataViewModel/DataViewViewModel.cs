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

        private ObservableCollection<Level> levels;
        private Level selectedLevel;
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
                OpenChangeSubjectDialog.RaiseCanExecuteChanged();
                RemoveSubject.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<Level> Levels
        {
            get { return levels; }
            set
            {
                levels = value;
                RaisePropertyChanged("Levels");
            }
        }
        public Level SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                selectedLevel = value;
                RaisePropertyChanged("SelectedLevel");
                OpenChangeLevelDialog.RaiseCanExecuteChanged();
                RemoveLevel.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand OpenAddSubjectDialog { get; private set; }
        public RelayCommand OpenChangeSubjectDialog { get; private set; }
        public RelayCommand RemoveSubject { get; private set; }

        public RelayCommand OpenAddLevelDialog { get; private set; }
        public RelayCommand OpenChangeLevelDialog { get; private set; }
        public RelayCommand RemoveLevel { get; private set; }

        #endregion

        #region Constructor
        public DataViewViewModel()
        {
            Levels = DataManager.Load<ObservableCollection<Level>>("Levels.xml");
            Subjects = DataManager.Load<ObservableCollection<Subject>>("Subjects.xml");

            OpenAddSubjectDialog = new RelayCommand(OpenAddSubjectDialog_Execute);
            OpenChangeSubjectDialog = new RelayCommand(OpenChangeSubjectDialog_Execute, () => { return SelectedSubject != null; });
            RemoveSubject = new RelayCommand(RemoveSubject_Execute, () => { return SelectedSubject != null; });

            OpenAddLevelDialog = new RelayCommand(OpenAddLevelDialog_Execute);
            OpenChangeLevelDialog = new RelayCommand(OpenChangeLevelDialog_Execute, () => { return SelectedLevel != null; });
            RemoveLevel = new RelayCommand(RemoveLevel_Execute, () => { return SelectedLevel != null; });
        }
        #endregion

        #region Commands

        #region Subjects
        private void OpenAddSubjectDialog_Execute()
        {
            View = new SubjectView();
            View.Window.Closing += ClosingSubjectDialog;
            View.ShowView(new SubjectViewViewModel(Subjects));
        }

        private void ClosingSubjectDialog(object sender, CancelEventArgs e)
        {
            DataManager.Save(Subjects, "Subjects.xml");
        }

        private void OpenChangeSubjectDialog_Execute()
        {
            View = new SubjectView();
            View.Window.Closing += UpdateChangeSubject;
            View.ShowView(new SubjectViewViewModel(SelectedSubject));
        }

        private void UpdateChangeSubject(object sender, CancelEventArgs e)
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
            DataManager.Save(Subjects, "Subjects.xml");
        }

        private void RemoveSubject_Execute()
        {
            foreach (var item in Subjects)
            {
                if (item == SelectedSubject)
                {
                    Subjects.Remove(SelectedSubject);
                    DataManager.Save(Subjects, "Subjects.xml");
                    break;
                }
            }
        }
        #endregion

        #region Level
        private void OpenAddLevelDialog_Execute()
        {
            View = new LevelView();
            View.Window.Closing += ClosingLevelDialog;
            View.ShowView(new LevelViewViewModel(Levels));
        }

        private void ClosingLevelDialog(object sender, CancelEventArgs e)
        {
            DataManager.Save(Levels, "Levels.xml");
        }

        private void OpenChangeLevelDialog_Execute()
        {
            View = new LevelView();
            View.Window.Closing += UpdateChangeLevel;
            View.ShowView(new LevelViewViewModel(SelectedLevel));
        }

        private void UpdateChangeLevel(object sender, CancelEventArgs e)
        {
            List<Level> collection = new List<Level>();
            foreach (var item in Levels)
            {
                collection.Add(item);
            }
            Levels.Clear();
            foreach (var item in collection)
            {
                Levels.Add(item);
            }
            DataManager.Save(Levels, "Levels.xml");
        }

        private void RemoveLevel_Execute()
        {
            foreach (var item in Levels)
            {
                if (item == SelectedLevel)
                {
                    Levels.Remove(SelectedLevel);
                    DataManager.Save(Levels, "Levels.xml");
                    break;
                }
            }
        }
        #endregion

        #endregion
    }
}
