using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Views.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HumanResourcesApplication_DoAn.Views.Admin;
using HumanResourcesApplication_DoAn.Repositories.DepartmentRepo;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class DepartmentViewModel : ViewModelBase
    {
        private string? _departmentID;
        private string? _departmentName;
        private string? _head;
        private string _totalEmployees;
        public string? DepartmentID { get => _departmentID; set { _departmentID = value; OnPropertyChanged(nameof(DepartmentID)); } }
        public string? DepartmentName { get => _departmentName; set { _departmentName = value; OnPropertyChanged(nameof(DepartmentName)); } }
        public string? Head { get => _head; set { _head = value; OnPropertyChanged(nameof(Head)); } }
        public string TotalEmployees { get => _totalEmployees; set { _totalEmployees = value; OnPropertyChanged(TotalEmployees); } }

        public IDeleteDepartmentRepository deleteDepartmentRepository { get; }


        private HumanResourcesApplication_DoAn.Model.Department _selectedItems;
        private IListDepartmentRepository? _departmentRepository;

        private List<HumanResourcesApplication_DoAn.Model.Department>? _listDepartment;

        public IListDepartmentRepository? DepartmentRepository
        {
            get => _departmentRepository;
            set
            {
                _departmentRepository = value;
                OnPropertyChanged(nameof(DepartmentRepository));
            }
        }
        public List<HumanResourcesApplication_DoAn.Model.Department>? ListDepartment
        {
            get => _listDepartment;
            set
            {
                _listDepartment = value;
                OnPropertyChanged(nameof(ListDepartment));
            }
        }
        
        //Command
        public ViewModelCommand DeleteDepartment { get; }
        public ViewModelCommand ChangeDepartmentCommand { get;}
        public ViewModelCommand AddDepartmentCommand { get; }
        public Model.Department SelectedItems { get => _selectedItems; set { _selectedItems = value; OnPropertyChanged(nameof(SelectedItems)); } }
        public ViewModelCommand DeleteCommand { get; }

        //Constructor
        public DepartmentViewModel()
        {
            DepartmentRepository = new ListDepartmentRepository();
            ListDepartment = new List<HumanResourcesApplication_DoAn.Model.Department>();
            ListDepartment = DepartmentRepository.ListDepartment();
            DeleteDepartment = new ViewModelCommand(ExcuteDeleteDepartment,CanExcuteDeleteDepartment);
            AddDepartmentCommand = new ViewModelCommand(ExcuteAddDepartment, CanExcuteAddDepartment);
            ChangeDepartmentCommand = new ViewModelCommand(ExcuteChangeDepartment, CanExcuteChangeDepartment);
            deleteDepartmentRepository = new DeleteDepartmentRepository();
            DeleteCommand = new ViewModelCommand(ExcuteDeleteDepartment);
        }
       
        private void ExcuteChangeDepartment (object? obj)
        {

        }
        private bool CanExcuteChangeDepartment(object? obj)
        {
            return true;
        }
        private void ExcuteAddDepartment(object? obj)
        {
            Department_Add addDepartmentView = new Department_Add();
            addDepartmentView.ShowDialog();
        }
        private bool CanExcuteAddDepartment(object? obj)
        {
            return true;
        }
        private void ExcuteDeleteDepartment(object? obj)
        {
            deleteDepartmentRepository.DeleteDepartment(SelectedItems.departmentId,SelectedItems.departmentName,SelectedItems.head,SelectedItems.totalEmployees);
            Application.Current.MainWindow.Close();
        }

        private bool CanExcuteDeleteDepartment(object? obj)
        {
            return true;
        }
    }
}
