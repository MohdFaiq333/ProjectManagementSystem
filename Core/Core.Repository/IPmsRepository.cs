using Core.Core.Entities;
using System.Collections.Generic;

namespace Core.Core.Repository
{
   public interface IPmsRepository
    {
        List<Department> GetDepartments();
        List<Project> GetProjectsList();
    }
}
