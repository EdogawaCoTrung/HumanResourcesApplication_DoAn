using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IChangeInsurance
    {
        public void ChangeInsurance(string InsuranceId, string UserId, string StartDate, string EndDate);
    }
}
