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
    public class AcademicPlanViewModel : ViewModelBase
    {
        private string name;
        private ObservableCollection<AcademicPlan> plan;
        private ObservableCollection<Level> levels;
        private Level selectedLevel;
        private ObservableCollection<Level> dataLevels;
        private Level selectedDataLevel;
        private ObservableCollection<Subject> subjects;

        public string Name { get { return name; } set { name = value; } }
        public ObservableCollection<AcademicPlan> Plan { get { return plan; } set { plan = value; } }
        public ObservableCollection<Level> Levels { get { return levels; } set { levels = value; } }
        public Level SelectedLevel { get { return selectedLevel; } set { selectedLevel = value; } }
        public ObservableCollection<Level> DataLevels { get { return dataLevels; } set { dataLevels = value; } }
        public Level SelectedDataLevel { get { return selectedDataLevel; } set { selectedDataLevel = value; RaisePropertyChanged("SelectedDataLevel"); } }
        public ObservableCollection<Subject> Subjects { get { return subjects; } set { subjects = value; } }

        public RelayCommand CreateAcademicPlan { get; private set; }
        public RelayCommand AddLevel { get; private set; }

        public AcademicPlanViewModel(ObservableCollection<AcademicPlan> academicPlan)
        {
            Plan = academicPlan;
            Levels = new ObservableCollection<Level>();
            DataLevels = DataManager.Load<ObservableCollection<Level>>("Levels.xml");
            CreateAcademicPlan = new RelayCommand(CreateAcademicPlan_Execute);
            AddLevel = new RelayCommand(AddLevel_Execute);
        }

        private void CreateAcademicPlan_Execute()
        {

        }

        private void AddLevel_Execute()
        {
            Levels.Add(SelectedDataLevel);
        }
    }
}
