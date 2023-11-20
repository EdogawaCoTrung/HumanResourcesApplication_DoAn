using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    internal class User
    {
        public string userId { get; set;}
        public string userName { get; set;}
        public string loginName { get; set;}
        public string password { get; set;}
        public bool isAdmin { get; set;}
        public string phoneNumber { get; set;}
        public string dateOfBirth { get; set;}
        public string countryId { get; set;}
        public string educationId { get; set;}
        public string email { get; set;}
        public string facebook { get; set;}
        public string twitter { get; set;}
        public string linkedIn { get; set;}
        public string departmentId { get; set;}
        public string joinDate { get; set;}
        public string roleId { get; set;}
        public string payrollId { get; set; }
    }
}
