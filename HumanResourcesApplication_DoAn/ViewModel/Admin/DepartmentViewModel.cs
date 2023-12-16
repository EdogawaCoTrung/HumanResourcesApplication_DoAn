using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HumanResourcesApplication_DoAn.Views.Admin;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Repositories.DepartmentRepo;
using HumanResourcesApplication_DoAn.Model;
using System.CodeDom;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class DepartmentViewModel:ViewModelBase
    {
        private string? _departmentID;
        private string? _departmentName;
        private string? _head;
        private string? _totalEmployees;
        private List<Model.Department> _listDepartments;
        public Model.Department _selectedItem;
        //properties
        public string? DepartmentID { get => _departmentID; set { _departmentID = value; OnPropertyChanged(nameof(DepartmentID)); }  }
        public string? DepartmentName { get => _departmentName; set { _departmentName = value; OnPropertyChanged(nameof(DepartmentName)); } }
        public string? Head { get => _head; set { _head = value; OnPropertyChanged(nameof(Head)); } }
        public string? TotalEmployees { get => _totalEmployees; set {_totalEmployees = value; OnPropertyChanged(TotalEmployees); }}
        public List<Model.Department> ListDepartments { get => _listDepartments; set { _listDepartments = value; OnPropertyChanged(nameof(ListDepartments)); } }
        public Model.Department Selectedtem { get => _selectedItem; set { _selectedItem = value; OnPropertyChanged(nameof(Selectedtem)); } }
        //command
        public IListDepartmentRepository listDepartmentRepository { get; }
        public IDeleteDepartmentRepository deleteDepartmentRepository { get; }
        public ViewModelCommand AddDepartmentCommand { get; }
        public ViewModelCommand DeleteDepartmentCommand { get; }
        public ViewModelCommand ChangeDepartmentCommand { get; }
   

        public DepartmentViewModel()
        {
            ListDepartments = new List<Model.Department>();
            deleteDepartmentRepository = new DeleteDepartmentRepository();
            
            listDepartmentRepository = new ListDepartmentRepository();
            ListDepartments = listDepartmentRepository.ListDepartment();
            AddDepartmentCommand = new ViewModelCommand(ExcuteAddDepartmentCommand);
            DeleteDepartmentCommand = new ViewModelCommand(ExcuteDeleteDepartmentCommand);
            ChangeDepartmentCommand = new ViewModelCommand(ExcuteChangDepartmentCommand);
        }

        private void ExcuteChangDepartmentCommand(object? obj)
        {
            try
            {
                Department_Change_xaml changeDepartment = new Department_Change_xaml();
                if (Selectedtem != null)
                {
                    changeDepartment.DataContext = new ChangeDepartmentViewModel(Selectedtem);
                    changeDepartment.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw new Exception();
            }

        }

        private void ExcuteDeleteDepartmentCommand(object? obj)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?","Thông báo",MessageBoxButton.YesNo,MessageBoxImage.Warning,MessageBoxResult.No)== MessageBoxResult.Yes) 
            {
                deleteDepartmentRepository.DeleteDepartment(Selectedtem.departmentId, Selectedtem.departmentName, Selectedtem.head, Selectedtem.totalEmployees);
            }                
            
        }

        private void ExcuteAddDepartmentCommand(object? obj)
        {
            Department_Add addDepartment = new Department_Add();
            addDepartment.ShowDialog();
        }
    }
}
