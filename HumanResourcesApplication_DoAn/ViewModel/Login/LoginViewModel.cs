﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Security;
using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System.Net;
using System.Threading;
using System.Security.Principal;
using HumanResourcesApplication_DoAn.Views.Employee;
using HumanResourcesApplication_DoAn.Views.Admin;
using MaterialDesignThemes.Wpf;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.ViewModel.Admin;
using HumanResourcesApplication_DoAn.ViewModel.EmployeeVM;
using System.Windows.Media.Imaging;

namespace HumanResourcesApplication_DoAn.ViewModel.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private string _loginName;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private string _loginImage;
        private AdminMainView _adminMainView;
        private EmployeeMainView _employeeMainView;
        private Admin.MainViewViewModel _mainViewModel = null;
        private EmployeeVM.MainViewViewModel _employeeMainViewModel = null;

        private IUserRepository userRepository;
        public string LoginName { get => _loginName; 
            set { 
                _loginName = value;
                OnPropertyChanged(nameof(LoginName));
            } 
        }
        public string Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }
        public string LoginImage { get => _loginImage; set { _loginImage = value; OnPropertyChanged(nameof(LoginImage)); } }

        // Commands

        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // Constructor

        public LoginViewModel()
        {
            BindingImage bindingImage = new BindingImage();
            BindingImage bindingIcon = new BindingImage();
            BitmapSource icon = new BitmapImage(new Uri(bindingIcon.ConvertPath("favicon.ico")));

            Application.Current.MainWindow.Icon = new BitmapImage();
            Application.Current.MainWindow.Icon = icon;
            LoginImage = bindingImage.ConvertPath("LoginImage.png");
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPasswordCommand("", ""));
        }

        private bool CanExecuteLoginCommand(object? obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(LoginName) || LoginName.Length < 3 || Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }

        private void ExecuteLoginCommand(object? obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(LoginName, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(LoginName), null);
                IsViewVisible = false;
                if (userRepository.GetByLoginName(LoginName).isAdmin == false)
                {
                    EmployeeMainView employeeMainView = new EmployeeMainView();
                    MyApp.currentUser = userRepository.GetByLoginName(LoginName);
                    employeeMainView.DataContext = new EmployeeVM.MainViewViewModel();
                    employeeMainView.Show();
                }
                else
                {
                    MyApp.currentUser = userRepository.GetByLoginName(LoginName);
                    AdminMainView _adminMainView = new AdminMainView();
                    _adminMainView.Show();
                   
                }
                Application.Current.MainWindow.Close();
            }
            else
            {
                ErrorMessage = "*Invalid loginName or password";
            }
        }

        private void ExecuteRecoverPasswordCommand(string loginName, string email)
        {
            throw new NotImplementedException();
        }
    }
}
