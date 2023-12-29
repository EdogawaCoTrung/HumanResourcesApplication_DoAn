using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IAddUserRepository
    {
        void AddUser(string? userName, string? loginName, string? password, string? isAdmin, string? phoneNumber, string? dateOfBirth, string? country, string? education, string? gender, string? joinDate, string? role, string? payroll, string? facebook, string? twitter, string? linkedIn, string? email, string? avatar, string? departmentId);
    }
}
