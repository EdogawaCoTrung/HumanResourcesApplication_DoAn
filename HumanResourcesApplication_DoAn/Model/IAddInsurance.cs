using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IAddInsurance
    {
        void AddInsurance(string UserId, string InsuranceId, string StartDate, string EndDate);
    }
}
