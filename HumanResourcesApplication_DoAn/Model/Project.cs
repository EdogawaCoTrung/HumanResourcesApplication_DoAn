using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.Model
{
    public class Project
    {
        public string? projectId { get; set; }
        public string? projectName { get; set;}
        public DateOnly? startDate { get; set;}
        public DateOnly? endDate { get; set;}
        public User? projectManager { get; set; }
        public Department? department { get; set; }
        public string? numOfMember { get; set; }   
        public string? description { get; set; }   

        public Project() 
        {
            projectManager = new User();
            department = new Department();
        }
    }
}
