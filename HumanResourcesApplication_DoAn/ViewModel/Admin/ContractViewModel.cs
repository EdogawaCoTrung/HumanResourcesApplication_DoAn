using HumanResourcesApplication_DoAn.Model;
using HumanResourcesApplication_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class ContractViewModel:ViewModelBase
    {
        private IListUsersRepository listUsersRepository;
        private List<User?> listUsers;
        private List<Contract?> _Users;
        public List<Contract?> Users { get => _Users; set { _Users = value; } }
        public ContractViewModel()
        {
            listUsersRepository = new ListUsersRepository();
            listUsers = new List<User>();
            listUsers = listUsersRepository.ListUsers();
            Users = new List<Contract?>();
            for(int i=0;i<listUsers.Count; i++)
            {
                Contract temp = new Contract();
                temp.user = listUsers[i];
                temp.startDate = listUsers[i].joinDate.ToString();
                temp.endDate = ((DateOnly)listUsers[i].joinDate).AddYears(5).ToString();
                temp.contractName = "Hợp đồng 5 năm";
                temp.status = "Signed";
                Users.Add(temp);
            }
        }

    }
}
