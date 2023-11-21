using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Security;

namespace HumanResourcesApplication_DoAn.ViewModel.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private string _loginName;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string LoginName { get => _loginName; 
            set { 
                _loginName = value;
                OnPropertyChanged(nameof(LoginName));
            } 
        }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }
        
        // Commands

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // Constructor

        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            
        }

        private bool CanExecuteLoginCommand(object? obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteLoginCommand(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
