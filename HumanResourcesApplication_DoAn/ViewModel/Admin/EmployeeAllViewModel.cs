﻿using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using HumanResourcesApplication_DoAn.Views.Admin;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeAllViewModel : ViewModelBase
    {
        private EmployeeMainViewViewModel mainViewVM;
        private int _totalEmployee;
        private int _newEmployee;
        private int _male;
        private int _female;
        private IListUsersRepository? listUsers;
        private User _selectedItem;
        public ICommand AddUserCommand { get; }
        private List<User>? users;
        
        public List<User>? Users { get => users;
            set {
                users = value;
                OnPropertyChanged(nameof(users));
            }
        }

        public int TotalEmployee { get => _totalEmployee; set { _totalEmployee = value; OnPropertyChanged(nameof(TotalEmployee)); } }
        public int NewEmployee { get => _newEmployee; set { _newEmployee = value; OnPropertyChanged(nameof(NewEmployee)); } }
        public int Male { get => _male; set { _male = value; OnPropertyChanged(nameof(Male)); } }
        public int Female { get => _female; set { _female = value; OnPropertyChanged(nameof(Female)); } }
        public User SelectedItem { get => _selectedItem; set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); } }
        

        public ViewModelCommand ShowEmployeeViewCommand { get; }
        public ViewModelCommand ChangeEmployeeCommand { get; }
        public ViewModelCommand DeleteEmployeeCommand { get; }

     
        public EmployeeAllViewModel(EmployeeMainViewViewModel mainViewVM)
        {
            this.mainViewVM = mainViewVM;
            AddUserCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            listUsers = new ListUsersRepository();
            Users = new List<User>();
            Users = listUsers.ListUsers();
            TotalEmployee = Users != null ? Users.Count : 0;
            NewEmployee = 0;
            Female = 0;
            Male = 0;
            if(Users != null)
                for(int i = 0; i < Users.Count; i++)
                {
                    if (Users[i].joinDate.Value.Year == DateTime.Now.Year)
                        NewEmployee++;
                    if (Users[i].gender == false)
                        Female++;
                    else
                        Male++;
                }

            ShowEmployeeViewCommand = new ViewModelCommand(ExcuteShowEmployeeViewCommand);
            ChangeEmployeeCommand = new ViewModelCommand(ExcuteChangeEmployeeViewCommand);
            DeleteEmployeeCommand = new ViewModelCommand(ExcuteDeleteEmployeeViewCommand);
                 
        }

       
       


        private bool CanExecuteAddCommand(object? obj)
        {
            return true;
        }
        private void ExcuteChangeEmployeeViewCommand(object? obj)
        {
            throw new NotImplementedException();
        }

        private void ExcuteDeleteEmployeeViewCommand(object? obj)
        {

        }

        private void ExcuteShowEmployeeViewCommand(object? obj)
        {
            try
            {
                if (SelectedItem != null)
                {

                    EmployeeViewViewModel employeeViewViewModel = new EmployeeViewViewModel(mainViewVM, this); 
                    mainViewVM.CurrentEmployeeChildView = employeeViewViewModel;
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        private void ExecuteAddCommand(object? obj)
        {
            Employee_AddUser employee_Add = new Employee_AddUser();
            employee_Add.ShowDialog();
        }
    }
}
