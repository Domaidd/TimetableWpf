using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TimetableWpf
{
    public class MainViewViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<AcademicPlan> academicPlan;
        private Boolean isSelected;
        private object selectedItem;
        #endregion

        #region Properties
        public IView View { get; set; }

        public Boolean IsSelected { get { return isSelected; } set { if (isSelected != value) { isSelected = value; RaisePropertyChanged("IsSelected"); } } }
        public object SelectedItem { get { return selectedItem; } set { if (selectedItem != value) { selectedItem = value; RaisePropertyChanged("SelectedItem"); } } }

        public ObservableCollection<AcademicPlan> AcademicPlan { get { return academicPlan; } set { academicPlan = value; RaisePropertyChanged("AcademicPlan"); } }

        public RelayCommand OpenDataView { get; private set; }
        public RelayCommand OpenCreatePlanDialog { get; private set; }
        #endregion

        #region Constructor
        public MainViewViewModel()
        {
            SelectedSubject = new ObservableCollection<Subject>();
            AcademicPlan = new ObservableCollection<AcademicPlan>()
                {
                    new AcademicPlan("2017-2018", new List<Level>
                    {
                        new Level("6 класс", new List<Subject>
                        {
                            new Subject("Математика", 6, 2),
                            new Subject("Русский язык", 6, 2),
                        }),
                        new Level("7 класс", new List<Subject>
                        {
                            new Subject("Математика", 5, 1),
                            new Subject("Русский язык", 4, 1),
                            new Subject("Физика", 4, 2)
                        })
                    }),
                    new AcademicPlan("2017-2018", new List<Level>
                    {
                        new Level("6 класс", new List<Subject>
                        {
                            new Subject("Математика", 6, 2),
                            new Subject("Русский язык", 6, 2),
                        }),
                        new Level("7 класс", new List<Subject>
                        {
                            new Subject("Математика", 5, 1),
                            new Subject("Русский язык", 4, 1),
                            new Subject("Физика", 4, 2)
                        })
                    })
                };
            OpenDataView = new RelayCommand(OpenDataView_Execute);
            OpenCreatePlanDialog = new RelayCommand(OpenCreatePlanDialog_Execute);
        }
        #endregion

        #region Commands
        private void OpenDataView_Execute()
        {
            View = new DataView();
            View.ShowView(new DataViewViewModel());
        }
        
        private void OpenCreatePlanDialog_Execute()
        {
            View = new AcademicPlanView();
            View.ShowView(new AcademicPlanViewModel(AcademicPlan));
        }
        #endregion

        #region TreeView
        private Level selectedLevel;
        private ObservableCollection<Subject> selectedSubject;
        private CustomRelayCommand selectedCommand;


        public Level SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                if (value != null)
                {
                    selectedLevel = value;
                    selectedLevel.Selected = true;
                    RaisePropertyChanged("Subject");
                }

            }
        }
        public ObservableCollection<Subject> SelectedSubject
        {
            get { return selectedSubject; }
            set { selectedSubject = value; }
        }
        public CustomRelayCommand SelectedCommand
        {
            get
            {
                if (selectedCommand == null)
                {
                    selectedCommand = new CustomRelayCommand(i => SetSelected(i), null);
                }
                return selectedCommand;
            }
        }

        private void SetSelected(object element)
        {
            SelectedSubject.Clear();
            Level subject = SelectedLevel;
            SelectedLevel = element as Level;
            if (subject != SelectedLevel)
            {
                foreach (var item in SelectedLevel.Subjects)
                {
                    SelectedSubject.Add(item);
                }
            }
        }
        #endregion
    }
}
