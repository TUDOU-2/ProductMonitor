using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProductMonitor.OpCommand
{
    public class Command : ICommand
    {
        private Action _execute;
        public event EventHandler? CanExecuteChanged;

        public Command(Action execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_execute != null)
            {
                _execute();
            }
        }
    }
}
