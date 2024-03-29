﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories.DepartmentRepo;
using HumanResourcesApplication_DoAn.Repositories;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    class AddDepartmentViewModel:ViewModelBase
    {
        private List<string> _listHeadDepartment;
        private List<User> _listHeadDepartmentUser;
        private string? _departmentName;
        private string? _head;
        private string? _totalEmployees;

        //command
        public IListUsersRepository listUsersRepository;
        public ViewModelCommand AddCommand { get; }
        public ViewModelCommand CancelCommand { get; }
        public IAddDepertmentRepository addDepertmentRepository { get; }
        public string? DepartmentName { get => _departmentName; set { _departmentName = value; OnPropertyChanged(nameof(Department)); } }
        public string? Head { get => _head; set { _head = value; OnPropertyChanged(nameof(Head)); } }
        public string? TotalEmployees { get => _totalEmployees; set { _totalEmployees = value; OnPropertyChanged(nameof(TotalEmployees)); } }

        public List<string> ListHeadDepartment { get => _listHeadDepartment; set { _listHeadDepartment = value; OnPropertyChanged(nameof(ListHeadDepartment)); } }

        public List<User> ListHeadDepartmentUser { get => _listHeadDepartmentUser; set { _listHeadDepartmentUser = value; OnPropertyChanged(nameof(ListHeadDepartmentUser)); } }
        
        public AddDepartmentViewModel()
        {
            listUsersRepository = new ListUsersRepository();
            _listHeadDepartment = new List<string>();
            ListHeadDepartmentUser = listUsersRepository.ListUsers();
            foreach(User user in ListHeadDepartmentUser)
            {
                ListHeadDepartment.Add(user.userName);
            }
            addDepertmentRepository = new AddDepartmentRepository() ;
            AddCommand = new ViewModelCommand(ExcuteAddCommand, CanExcuteAddCommand);
            CancelCommand = new ViewModelCommand(ExcuteCancelCommand, CanExcuteCancelCommand);

        }
        private void ExcuteAddCommand(object? obj)
        {
            foreach (User user in ListHeadDepartmentUser)
            {
                if (user.userName == Head) 
                {
                    Head = user.userId;
                    break;
                }
            }
            addDepertmentRepository.AddDepartment(DepartmentName, Head, int.Parse(TotalEmployees));
            Application.Current.MainWindow.Close();
        }
        private bool CanExcuteAddCommand(object? obj)
        {
            bool IsValid = true;
            if(DepartmentName==""||DepartmentName==null)
            {
                IsValid = false;
            }
            else if(Head == ""||Head == null) { IsValid = false; }
            else if (TotalEmployees==null) { IsValid = false; }
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
