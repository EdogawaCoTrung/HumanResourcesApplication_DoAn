using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IAddPayrollHistoryRepository
    {
        public void AddPayrollHistory(string? _userId, string? _payrollId, DateOnly? _startDate, DateOnly? _endDate);
    }
}
