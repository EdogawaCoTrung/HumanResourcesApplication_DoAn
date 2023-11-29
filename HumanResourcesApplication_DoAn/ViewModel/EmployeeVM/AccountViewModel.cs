using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.ViewModel.Login;
using HumanResourcesApplication_DoAn.Views.Employee;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class AccountViewModel : ViewModelBase
    {

        User _user;
        public User user { get => _user; set { _user = value; OnPropertyChanged(nameof(user)); } }

        public ICommand LeaveCommand { get; }
        public ICommand ChangeCommand { get; }
        public ICommand FacebookCommand { get; }
        public ICommand TwitterCommand { get; }
        public ICommand LinkedInCommand {get; }
        public ICommand PhoneNumberCommand { get; }


        public AccountViewModel()
        {
            user = new User();
            user = MyApp.currentUser;
            BindingImage bindingImage = new BindingImage();
            LeaveCommand = new ViewModelCommand(ExecuteLeaveCommand, CanExecuteLeaveCommand);
            ChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            FacebookCommand = new ViewModelCommand(ExecuteFacebookCommand, CanExecuteFacebookCommand);
            TwitterCommand = new ViewModelCommand(ExecuteTwitterCommand, CanExecuteTwitterCommand);
            LinkedInCommand = new ViewModelCommand(ExecuteLinkedInCommand, CanExecuteLinkedInCommand);
            PhoneNumberCommand = new ViewModelCommand(ExecutePhoneNumberCommand, CanExecutePhoneNumberCommand);
        }


        private bool CanExecuteChangeCommand(object? obj)
        {
            return true;
        }

        private void ExecuteChangeCommand(object? obj)
        {
            Employee_Account_ChangeView changeView = new Employee_Account_ChangeView();
            changeView.ShowDialog();
        }

        private void ExecuteLeaveCommand(object? obj)
        {
            AddLeaveRequest addLeaveRequest = new AddLeaveRequest();
            addLeaveRequest.ShowDialog();
        }
        private bool CanExecuteLeaveCommand(object? obj)
        {
            return true;
        }

        private bool CanExecutePhoneNumberCommand(object? obj)
        {
            return true;
        }

        private void ExecutePhoneNumberCommand(object? obj)
        {
            MessageBox.Show(user.phoneNumber);
        }

        private bool CanExecuteLinkedInCommand(object? obj)
        {
            return true;
        }

        private void ExecuteLinkedInCommand(object? obj)
        {
            MessageBox.Show(user.linkedIn);
        }

        private bool CanExecuteTwitterCommand(object? obj)
        {
            return true;
        }

        private void ExecuteTwitterCommand(object? obj)
        {
            MessageBox.Show(user.twitter);
        }

        private bool CanExecuteFacebookCommand(object? obj)
        {
            return true;
        }

        private void ExecuteFacebookCommand(object? obj)
        {
            MessageBox.Show(user.facebook);
        }
    }
}
