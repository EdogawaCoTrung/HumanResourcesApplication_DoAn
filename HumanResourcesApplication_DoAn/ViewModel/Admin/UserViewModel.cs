using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Utils;
using HumanResourcesApplication_DoAn.Views.Admin;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class UserViewModel:ViewModelBase
    {
        User _user;
        public User user
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(user));
            }
        }
      
        //command
        public ViewModelCommand SendLeaveRequestCommand  { get; }
        public ViewModelCommand ChangeInformationCommand{ get;}
        public UserViewModel()
        {
            _user = new User();
            _user = MyApp.currentUser;
            SendLeaveRequestCommand = new ViewModelCommand(ExcuteSendLeaveRequestCommand, CanExcuteSendLeaveRequestCommand);

            ChangeInformationCommand = new ViewModelCommand(ExcuteChangeInformationCommand, CanExcuteChangeInformationCommand);


        }

        private bool CanExcuteChangeInformationCommand(object? obj)
        {
            return true;
        }

        private void ExcuteChangeInformationCommand(object? obj)
        {
            //try
            //{
            //    Department_Change_xaml changeDepartment = new Department_Change_xaml();
            //    if (Selectedtem != null)
            //    {
            //        changeDepartment.DataContext = new ChangeDepartmentViewModel(Selectedtem);
            //        changeDepartment.ShowDialog();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception();
            //}
        }

        private bool CanExcuteSendLeaveRequestCommand(object? obj)
        {
            return true;
        }

        private void ExcuteSendLeaveRequestCommand(object? obj)
        {
            User_AddLeaveRequest leaveRequestView = new User_AddLeaveRequest();
            leaveRequestView.ShowDialog();
        }
    }
}
