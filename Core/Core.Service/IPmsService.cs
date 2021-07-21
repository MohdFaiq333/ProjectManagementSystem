using Core.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Core.Service
{
   public interface IPmsService
    {
        List<Department> GetDepartments();
        List<Project> GetProjectsList();
    }
}
