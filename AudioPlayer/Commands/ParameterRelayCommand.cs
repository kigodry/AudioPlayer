using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AudioPlayer
{
    public class ParameterRelayCommand<T> : ICommand
    {
        private Action<T> _action;
        public event EventHandler? CanExecuteChanged;

        public ParameterRelayCommand(Action<T> action)
        {
            _action = action;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter!=null)
            {
                _action((T)parameter);
            }
        }
    }
}
