﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class Payroll
    {
        public string? payrollId { get; set; }
        public string? roleID { get; set; }
        public int? salary { get; set; }
        public virtual User? user { get; set; }
        public virtual Role? role { get; set; }
        public virtual Department? department { get; set; }
        public Payroll()
        {
            user = new User();
            role = new Role();
            department = new Department();
        }
    }
}
