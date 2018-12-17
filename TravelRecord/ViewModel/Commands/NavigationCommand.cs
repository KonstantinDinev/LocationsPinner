using System;
using System.Windows.Input;

namespace TravelRecord
{
    public class NavigationCommand : ICommand
    {
        public HomeViewModel HomeViewModel { get; set; }


        public NavigationCommand(HomeViewModel HomeVM)
        {
            this.HomeViewModel = HomeVM;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            HomeViewModel.Navigate();
        } 
    }
}
