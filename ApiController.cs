using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SemiApprenticeship.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemiApprenticeship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        TasksDAL td = new TasksDAL();
        UsersDAL ud = new UsersDAL();

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var res = td.GetPendingTasks();
            return Ok(res);
        }

        [HttpGet]
        [Route("Get2")]
        public IActionResult Get2()
        {
            var res = ud.ActiveUsers();
            return Ok(res);
        }
    }
}
