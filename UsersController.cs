using Microsoft.AspNetCore.Mvc;
using SemiApprenticeship.DataAccessLayer;
using SemiApprenticeship.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemiApprenticeship.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Users user)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsersDAL ud = new UsersDAL();

                    if(ud.AddUsers(user))
                    {
                        ViewBag.Message = "User added!";
                    }
                }
                
                return ViewBag();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Users()
        {
            UsersDAL ud = new UsersDAL();
            ModelState.Clear();
            return View(ud.ActiveUsers());
        }

        public IActionResult Edit(int id)
        {
            UsersDAL ud = new UsersDAL();
            return View(ud.ActiveUsers().Find(i => i.UserId==id));
        }
        [HttpPost]
        public IActionResult Edit(int id, Users user)
        {
            try
            {
                UsersDAL ud = new UsersDAL();
                ud.EditUsers(user);
                return RedirectToAction("Users");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            UsersDAL ud = new UsersDAL();
            return View(ud.ActiveUsers().Find(i=>i.UserId==id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            UsersDAL UD = new UsersDAL();
            UD.DeleteUsers(id);
            return RedirectToAction("Users");
        }
    }
}
