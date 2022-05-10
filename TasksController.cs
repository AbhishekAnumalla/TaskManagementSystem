using Microsoft.AspNetCore.Mvc;
using SemiApprenticeship.DataAccessLayer;
using SemiApprenticeship.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemiApprenticeship.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Tasks()
        {
            TasksDAL td = new TasksDAL();
            ModelState.Clear();
            return View(td.GetPendingTasks());
        }

        public IActionResult Approve(int id)
        {
            TasksDAL td = new TasksDAL();
            td.ApproveTask(id);
            return RedirectToAction("Tasks");
        }

        public IActionResult Reject(int id)
        {
            TasksDAL td = new TasksDAL();
            td.RejectTask(id);
            return RedirectToAction("Tasks");
        }
    }
}
