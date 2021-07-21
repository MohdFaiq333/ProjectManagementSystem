using PMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Core.Repository
{
   public interface IPmsRepository
    {
        int UserLogin(string email, string password);
        ProjectsDetail GetProjectsList(int page,int pageSize);
    }
}
