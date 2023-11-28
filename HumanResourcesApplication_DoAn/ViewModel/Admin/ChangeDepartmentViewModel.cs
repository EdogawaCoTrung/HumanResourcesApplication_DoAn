using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories.DepartmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class ChangeDepartmentViewModel:ViewModelBase
    {
        private string _departmentID;
        private string? _departmentName;
        private string? _head;
        private string? _totalEmployees;
        private Department _selectedItem;

        //command
        public ViewModelCommand ChangeCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public IChangeDepartmentRepository changeDepertmentRepository { get; }
        public string? DepartmentName { get => _departmentName; set { _departmentName = value; OnPropertyChanged(nameof(Department)); } }
        public string? Head { get => _head; set { _head = value; OnPropertyChanged(nameof(Head)); } }
        public string? TotalEmployees { get => _totalEmployees; set { _totalEmployees = value; OnPropertyChanged(nameof(TotalEmployees)); } }

        public string DepartmentId { get => _departmentID; set { _departmentID = value; OnPropertyChanged(nameof(DepartmentId)); } }

        public Department SelectedItem { get => _selectedItem; set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); } }

        public ChangeDepartmentViewModel(Department SelectedItem)
        {
            changeDepertmentRepository = new ChangeRepository();
            ChangeCommand = new ViewModelCommand(ExcuteChangeCommand, CanExcuteAddCommand);
            CancelCommand = new ViewModelCommand(ExcuteCancelCommand, CanExcuteCancelCommand);
            _departmentID = SelectedItem.departmentId;
            _departmentName = SelectedItem.departmentName;
            _head = SelectedItem.head;
            _totalEmployees = SelectedItem.totalEmployees.ToString();


        }
        private void ExcuteChangeCommand(object? obj)
        {
            changeDepertmentRepository.ChangeDepartment(DepartmentId,DepartmentName, Head, int.Parse(TotalEmployees));
            Application.Current.MainWindow.Close();
        }
        private bool CanExcuteAddCommand(object? obj)
        {
            bool IsValid = true;
            if (DepartmentName == "" || DepartmentName == null)
            {
                IsValid = false;
            }
            else if (Head == "" || Head == null) { IsValid = false; }
            else if (TotalEmployees == null) { IsValid = false; }
            return IsValid;
        }
        private void ExcuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }

        private bool CanExcuteCancelCommand(object? obj)
        {
            return true;
        }


    }
}