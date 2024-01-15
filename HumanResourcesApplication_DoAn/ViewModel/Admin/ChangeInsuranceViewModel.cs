using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class ChangeInsuranceViewModel:ViewModelBase
    {
        private InsuranceForView _insuranceForView;
        private string _insuranceName;
        private List<string> _sourceInsurance;
        private List<Insurance> _listInsurance;
        private string _userName;
        private List<string> _sourceUser;
        private List<User> _listUser;
        private IListUsersRepository listUsersRepository;
        private IListInsurance listInsurance;
        public IChangeInsurance changeInsurance;

        private DateTime _startDate;
        private DateTime _endDate;
        public ChangeDate changeDate;
        public ViewModelCommand ChangeCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public string InsuranceName { get => _insuranceName; set { _insuranceName = value; OnPropertyChanged(nameof(InsuranceName)); } }
        public List<string> SourceInsurance { get => _sourceInsurance; set { _sourceInsurance = value; OnPropertyChanged(nameof(SourceInsurance)); } }
        public List<Insurance> ListInsurance { get => _listInsurance; set { _listInsurance = value; OnPropertyChanged(nameof(ListInsurance)); } }
        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); } }
        public List<string> SourceUser { get => _sourceUser; set { _sourceUser = value; OnPropertyChanged(nameof(SourceUser)); } }
        public List<User> ListUser { get => _listUser; set { _listUser = value; OnPropertyChanged(nameof(ListUser)); } }
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public InsuranceForView SelectedInsuranceForView { get => _insuranceForView; set { _insuranceForView = value; OnPropertyChanged(nameof(SelectedInsuranceForView)); } }
        public ChangeInsuranceViewModel(InsuranceForView SelectedInsuranceForView)
        {
            this.SelectedInsuranceForView = SelectedInsuranceForView;
            InsuranceName = SelectedInsuranceForView._insuranceName;
            UserName = SelectedInsuranceForView._userName;
            StartDate = DateTime.Parse(SelectedInsuranceForView.startDate);
            EndDate = DateTime.Parse(SelectedInsuranceForView.endDate);
            changeDate = new ChangeDate();
            listUsersRepository = new ListUsersRepository();
            listInsurance = new ListInsuranceRepository();
            ListInsurance = listInsurance.ListInsurance();
            changeInsurance = new ChangeInsuranceRepository();
            SourceInsurance = new List<string>();
            foreach (Insurance insurance in ListInsurance)
            {
                SourceInsurance.Add(insurance.insuranceType);
            }
            listUsersRepository = new ListUsersRepository();
            ListUser = listUsersRepository.ListUsers();
            SourceUser = new List<string>();
            foreach (User user in ListUser)
            {
                SourceUser.Add(user.userName);
            }

            ChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }

        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }

        private bool CanExecuteChangeCommand(object? obj)
        {
            bool canExecute = true;
            if (UserName == "" || UserName == null)
            {
                canExecute = false;
            }
            if (InsuranceName == "" || InsuranceName == null)
            {
                canExecute = false;
            }
            if (StartDate == null || EndDate == null)
            {
                canExecute = false;
            }
            return canExecute;
        }

        private void ExecuteChangeCommand(object? obj)
        {
            string tempStartDate = changeDate.ChangeDateFormat(StartDate);
            string tempEndDate = changeDate.ChangeDateFormat(EndDate);
            foreach (Insurance insurance in ListInsurance)
            {
                if (InsuranceName == insurance.insuranceType)
                {
                    InsuranceName = insurance.insuranceId;
                }
            }
            foreach (User user in ListUser)
            {
                if (UserName == user.userName)
                {
                    UserName = user.userId;
                }
            }
            changeInsurance.ChangeInsurance(InsuranceName,UserName,tempStartDate,tempEndDate); 
            Application.Current.MainWindow.Close();
        }
    }
}
