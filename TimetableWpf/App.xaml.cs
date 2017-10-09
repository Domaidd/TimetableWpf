using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TimetableWpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow mainWindow;
        private MainViewViewModel mainViewViewModel;

        private void AppStartup(object sender, StartupEventArgs e)
        {
            mainViewViewModel = new MainViewViewModel();
            mainWindow = new MainWindow
            {
                DataContext = mainViewViewModel
            };
            mainWindow.Show();
        }
    }
}
