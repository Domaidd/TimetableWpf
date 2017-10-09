using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimetableWpf
{
    public class CustomRelayCommand : ICommand
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public CustomRelayCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public CustomRelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _Execute = execute ?? throw new ArgumentNullException("execute", "Execute cannot be null.");
            _CanExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecute == null)
            {
                return true;
            }

            return _CanExecute(parameter);
        }
    }
}
