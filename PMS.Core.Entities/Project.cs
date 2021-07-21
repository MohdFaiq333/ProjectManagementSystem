using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Core.Entities
{
   public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStartDate { get; set; }
        public string ProjectEndDate { get; set; }
        public string ProjectManagerName { get; set; }
        public string ProjectManagerEmail { get; set; }
        public List<Employee> employees { get; set; }
    }
}
