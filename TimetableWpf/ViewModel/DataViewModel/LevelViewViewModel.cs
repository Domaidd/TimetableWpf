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
    public class LevelViewViewModel : ViewModelBase
    {
        private string name;
        private Level selectedLevel;
        public ObservableCollection<Level> levels;

        public string Name { get { return name; } set { name = value; RaisePropertyChanged("Name"); } }
        public Level SelectedLevel { get { return selectedLevel; } set { selectedLevel = value; RaisePropertyChanged("SelectedLevel"); } }
        public ObservableCollection<Level> Levels { get { return levels; } set { levels = value; RaisePropertyChanged("Levels"); } }

        public RelayCommand AddLevel { get; private set; }
        public RelayCommand ChangeLevel { get; private set; }

        public Visibility IsEnabledAdd { get; set; }
        public Visibility IsEnabledChange { get; set; }

        public LevelViewViewModel(ObservableCollection<Level> levels)
        {
            Levels = levels;
            IsEnabledChange = Visibility.Hidden;
            IsEnabledAdd = Visibility.Visible;
            AddLevel = new RelayCommand(AddLevel_Execute);
        }

        public LevelViewViewModel(Level selectedLevel)
        {
            Name = selectedLevel.Name;
            SelectedLevel = selectedLevel;
            IsEnabledAdd = Visibility.Hidden;
            IsEnabledChange = Visibility.Visible;
            ChangeLevel = new RelayCommand(ChangeLevel_Execute, ChangeSubject_CanExecute);
        }

        public void AddLevel_Execute()
        {
            Levels.Add(new Level(Name));
        }

        private void ChangeLevel_Execute()
        {
            SelectedLevel.Name = Name;
        }

        private bool ChangeSubject_CanExecute()
        {
            return true;
        }
    }
}
