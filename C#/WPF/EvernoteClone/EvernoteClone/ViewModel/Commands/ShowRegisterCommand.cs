using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvernoteClone.ViewModel.Commands
{
    public class ShowRegisterCommand : ICommand
    {
        public LoginViewModel LoginViewModel { get; set; }
        public ShowRegisterCommand(LoginViewModel loginViewModel)
        {
            LoginViewModel = loginViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LoginViewModel.SwitchViews();
        }
    }
}
