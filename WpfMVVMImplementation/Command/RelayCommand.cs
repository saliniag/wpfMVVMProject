using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMVVMImplementation.Command
{
    public class RelayCommand : ICommand
    {
        Action<object> ExecuteActiion;
        Func<object, bool> canExecute;
        bool canExecuteCatche;

        //constructor
        public RelayCommand(Action<object> ExecuteActiion, Func<object, bool> canExecute, bool canExecuteCatche)
        {
            this.ExecuteActiion = ExecuteActiion;
            this.canExecute = canExecute;
            canExecuteCatche = canExecuteCatche;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (!canExecuteCatche)
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            ExecuteActiion(parameter);
        }
    }
}
