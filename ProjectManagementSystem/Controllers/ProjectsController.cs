using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PMS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProjectsController : Controller
    {
        private IPmsService _pmsService;
        public ProjectsController(IPmsService pmsService)
        {
            _pmsService = pmsService;
        }

       [HttpGet]
       //it will retrieve data based on the page no. and the pagesize
        public IActionResult GetProjectsList(int page,int pageSize)
        {
            var result = _pmsService.GetProjectsList(page, pageSize);
            return Json(result);
        }
    }
}
