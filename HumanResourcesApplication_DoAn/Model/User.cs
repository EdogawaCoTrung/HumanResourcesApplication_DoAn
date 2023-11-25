using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class User
    {
        public string? userId { get; set;}
        public string? userName { get; set;}
        public string? loginName { get; set;}
        public string? password { get; set;}
        public bool isAdmin { get; set;}
        public string? phoneNumber { get; set;}
        public DateTime dateOfBirth { get; set;}
        public string? countryId { get; set;}
        public string? educationId { get; set;}
        public string? email { get; set;}
        public string? facebook { get; set;}
        public string? twitter { get; set;}
        public string? linkedIn { get; set;}
        public string? departmentId { get; set;}
        public DateTime joinDate { get; set;}
        public string? roleId { get; set;}
        public string? payrollId { get; set; }
        public string? avatar { get; set;}
        public bool gender { get; set;}
        public string? insuranceId { get; set;}
    }
}
