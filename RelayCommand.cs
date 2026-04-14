using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VisualStudioLauncher
{
    public class RelayCommand : ICommand
    {
        Action<object> executeMethod = null;
        Func<object, bool> canExecuteMethod = null;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> _executeMethod, Func<object, bool> _canExecuteMethod = null)
        {
            executeMethod = _executeMethod;
            canExecuteMethod = _canExecuteMethod;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecuteMethod == null || canExecuteMethod(parameter);
        }

        public void Execute(object? parameter)
        {
            executeMethod?.Invoke(parameter);
        }
    }
}
