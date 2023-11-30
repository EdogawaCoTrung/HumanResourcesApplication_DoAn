using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesApplication_DoAn.Model;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeChangeViewModel:ViewModelBase
    {
        private User? _selectedItem;

        public User? SelectedItem 
        { 
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ViewModelCommand ClickChangeEmployeeCommand { get;  }
        public ViewModelCommand ClickCancelCommand { get; }
        public EmployeeChangeViewModel(User SelectedItem)
        {
            _selectedItem = SelectedItem;

            ClickChangeEmployeeCommand = new ViewModelCommand(ExcuteChangeEmployeeCommand, CanExcuteChangeEmployeeCommand);
            ClickCancelCommand = new ViewModelCommand(ExcuteCancelCommand);

        }

        private bool CanExcuteChangeEmployeeCommand(object? obj)
        {
            bool canExecute = true;
            if (SelectedItem.userName == null || SelectedItem.userName == "")
                canExecute = false;
            if (SelectedItem.loginName == null || SelectedItem.loginName == "")
                canExecute = false;
            if (SelectedItem.password == null || SelectedItem.password == "")
                canExecute = false;
            if (SelectedItem.isAdmin == null || SelectedItem.isAdmin.ToString() == "")
                canExecute = false;
            if (SelectedItem.phoneNumber == null || SelectedItem.phoneNumber == "")
                canExecute = false;
            if (SelectedItem.dateOfBirth == null || SelectedItem.dateOfBirth.ToString() == "")
                canExecute = false;
            if (SelectedItem.countryId == null || SelectedItem.countryId == "")
                canExecute = false;
            if (SelectedItem.educationId == null || SelectedItem.educationId == "")
                canExecute = false;
            if (SelectedItem.gender == null || SelectedItem.gender == "")
                canExecute = false;
            if (SelectedItem.joinDate == null || SelectedItem.joinDate.ToString() == "")
                canExecute = false;
            if (SelectedItem.roleId == null || SelectedItem.roleId== "")
                canExecute = false;
            if (SelectedItem.payrollId == null || SelectedItem.payrollId     == "")
                canExecute = false;
            if (SelectedItem.facebook == null || SelectedItem.facebook == "")
                canExecute = false;
            if (SelectedItem.twitter == null || SelectedItem.twitter == "")
                canExecute = false;
            if (SelectedItem.linkedIn == null || SelectedItem.linkedIn == "")
                canExecute = false;
            if (SelectedItem.email == null || SelectedItem.email == "")
                canExecute = false;
            if (SelectedItem.avatar == null & SelectedItem.avatar == "")
                canExecute = false;
            return canExecute;
        }

        private void ExcuteCancelCommand(object? obj)
        {
            throw new NotImplementedException();
        }

        private void ExcuteChangeEmployeeCommand(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
