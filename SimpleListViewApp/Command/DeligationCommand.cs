using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleListViewApp.Command
{
    public class DelegatingCommand: ICommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecute;

        public DelegatingCommand(Action executeAction)
            : this((o) => executeAction())
        { }

        public DelegatingCommand(Action<object> executeAction)
           : this(executeAction, (o) => true)
        { }

        public DelegatingCommand(Action<object> executeAction,Func<object,bool> canExecute)
        {
            this._executeAction = executeAction;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        // Invocation of delegated command
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
