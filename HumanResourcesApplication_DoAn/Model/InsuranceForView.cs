using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class InsuranceForView
    {
        public string _insuranceId { get; set; }
        public string _insuranceName { get; set; }
        public string _userName { set; get; }
        public string startDate { set; get; }
        public string endDate { set; get; }
    }
}
