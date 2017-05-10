using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankDB
{
    public class RelayCommand : ICommand
    {
        private Action<object> _executeDelegate;
        public RelayCommand(Action<object> executeDelegate)
        {
            _executeDelegate = executeDelegate;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeDelegate(parameter);
        }
    }
}
