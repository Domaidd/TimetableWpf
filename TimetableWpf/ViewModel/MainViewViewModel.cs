using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableWpf
{
    public class MainViewViewModel : ViewModelBase
    {
        #region Fields

        #endregion

        #region Properties
        public IView View { get; set; }

        public RelayCommand OpenDataView { get; private set; }
        #endregion

        #region Constructor
        public MainViewViewModel()
        {
            OpenDataView = new RelayCommand(OpenDataView_Execute);
        }
        #endregion

        #region Commands
        private void OpenDataView_Execute()
        {
            View = new DataView();
            View.ShowView(new DataViewViewModel());
        }
        #endregion
    }
}
