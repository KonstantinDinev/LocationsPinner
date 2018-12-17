using System;
using System.Windows.Input;

namespace TravelRecord
{
    public class RegisterNavigationCommand : ICommand
    {
        private MainViewModel viewModel;

        public RegisterNavigationCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.Navigate();
        }
    }
}
