using HumanResourcesApplication_DoAn.Views.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class Contract
    {
        public string? contractName { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public string? status { get; set; }
        public virtual User? user { get; set; }
        public Contract()
        {
            user = new User();
        }
    }
}
