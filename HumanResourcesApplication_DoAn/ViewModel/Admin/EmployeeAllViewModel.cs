using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeAllViewModel : ViewModelBase
    {
        private int _totalEmployee;
        private int _newEmployee;
        private int _male;
        private int _female;
        private IListUsersRepository? listUsers;
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

        public EmployeeAllViewModel()
        {
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
                    if (Users[i].joinDate.Year == DateTime.Now.Year)
                        NewEmployee++;
                    if (Users[i].gender == false)
                        Female++;
                    else
                        Male++;
                }
        }
    }
}
