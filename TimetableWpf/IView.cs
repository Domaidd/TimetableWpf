using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TimetableWpf
{
    public interface IView
    {
        void ShowView(ViewModelBase viewModelBase);

        Window Window { get; }
    }
}
