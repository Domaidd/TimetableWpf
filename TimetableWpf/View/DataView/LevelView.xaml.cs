using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;

namespace TimetableWpf
{
    /// <summary>
    /// Логика взаимодействия для LevelView.xaml
    /// </summary>
    public partial class LevelView : Window, IView
    {
        public Window Window { get; }

        public LevelView()
        {
            Window = this;
            InitializeComponent();
        }

        public void ShowView(ViewModelBase viewModelBase)
        {
            Window.DataContext = viewModelBase;
            Window.ShowDialog();
        }
    }
}
