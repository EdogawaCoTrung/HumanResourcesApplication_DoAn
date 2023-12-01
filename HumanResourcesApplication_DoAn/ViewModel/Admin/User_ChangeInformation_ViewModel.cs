using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class User_ChangeInformation_ViewModel:ViewModelBase
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set 
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public IChangeProfileRepository changeProfileRepository;
        public ViewModelCommand ChangeCommand { get; }
        public ViewModelCommand CancelCommand { get; }

        public User_ChangeInformation_ViewModel()
        {
            User = MyApp.currentUser;
            changeProfileRepository = new ChangeProfileRepository();
            ChangeCommand = new ViewModelCommand(ExcuteChangeCommand,CanExcuteChangeCommand);
            CancelCommand = new ViewModelCommand(ExcuteCancelCommand);
        }
        private void ExcuteCancelCommand(object? obj)
        {
            
            Application.Current.MainWindow.Close();
        }
        private void ExcuteChangeCommand(object? obj)
        {
            MessageBox.Show("Changed");
          

        }
        private bool CanExcuteChangeCommand(object? obj)
        {
            bool canExecute = true;
            if (User.userName == null || User.userName == "")
                canExecute = false;
            if (User.loginName == null || User.loginName == "")
                canExecute = false;
            if (User.password == null || User.password == "")
                canExecute = false;
            if (User.isAdmin == null || User.isAdmin.ToString() == "")
                canExecute = false;
            if (User.phoneNumber == null || User.phoneNumber == "")
                canExecute = false;
            if (User.dateOfBirth == null || User.dateOfBirth.ToString() == "")
                canExecute = false;
            if (User.countryId == null || User.countryId == "")
                canExecute = false;
            if (User.educationId == null || User.educationId == "")
                canExecute = false;
            if (User.gender == null || User.gender == "")
                canExecute = false;
            if (User.joinDate == null || User.joinDate.ToString() == "")
                canExecute = false;
            if (User.roleId == null || User.roleId == "")
                canExecute = false;
            if (User.payrollId == null || User.payrollId == "")
                canExecute = false;
            if (User.facebook == null || User.facebook == "")
                canExecute = false;
            if (User.twitter == null || User.twitter == "")
                canExecute = false;
            if (User.linkedIn == null || User.linkedIn == "")
                canExecute = false;
            if (User.email == null || User.email == "")
                canExecute = false;
            if (User.avatar == null & User.avatar == "")
                canExecute = false;
            return canExecute;
        }
    }
}
