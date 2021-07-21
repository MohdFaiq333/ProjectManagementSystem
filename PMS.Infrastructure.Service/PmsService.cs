using PMS.Core.Entities;
using PMS.Core.Service;
using PMS.Core.Repository;
using System.Collections.Generic;

namespace PMS.Infrastructure.Service
{
    public class PmsService : IPmsService
    {
        private IPmsRepository _pmsRepository;
        public PmsService(IPmsRepository pmsRepository)
        {
            _pmsRepository = pmsRepository; ;
        }

        public ProjectsDetail GetProjectsList(int page,int pageSize)
        {
            return _pmsRepository.GetProjectsList(page,pageSize);
        }

        public int UserLogin(string email, string password)
        {
            return _pmsRepository.UserLogin(email, password);
        }
    }
}
