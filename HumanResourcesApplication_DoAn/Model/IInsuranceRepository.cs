using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public interface IInsuranceRepository
    {
        void Add(Insurance user);
        void Edit(Insurance user);
        void Remove(string? insuranceId);
        User GetById(string? insuranceId);
        List<InsuranceForView> GetByAll();
    }
}
