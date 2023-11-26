using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.ViewModel.Login;
using HumanResourcesApplication_DoAn.Views.Employee;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HumanResourcesApplication_DoAn.ViewModel.EmployeeVM
{
    public class AccountViewModel : ViewModelBase
    {

        IUserRepository userRepository;
        User _user;
        public User user { get => _user; set { _user = value; OnPropertyChanged(nameof(user)); } }

        public ICommand LeaveCommand { get; }


        public AccountViewModel()
        {
            userRepository = new UserRepository();
            user = new User();
            user = MyApp.currentUser;
            LeaveCommand = new ViewModelCommand(ExecuteLeaveCommand, CanExecuteLeaveCommand);
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

    }
}
