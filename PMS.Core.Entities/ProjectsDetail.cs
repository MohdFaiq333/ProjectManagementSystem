using System.Collections.Generic;

namespace PMS.Core.Entities
{
   public class ProjectsDetail
    {
       public List<Project> data { get; set; }
        public int Page { get; set; } 
        public int PageSize { get; set; } 
        public int TotalItems { get; set; }
    }
}
