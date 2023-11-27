using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IChangeProfileRepository
    {
       void ChangeProfile(string? loginName, string? userName, string? password, string? phoneNumber, string? dateOfBirth, string? gender, string? country, string? education, string? facebook, string? twitter, string? linkedIn, string? email, string? avatar);
    }
}
