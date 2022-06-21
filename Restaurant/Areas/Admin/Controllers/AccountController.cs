using Restaurant.DAL;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private FoodDbContext _context;

        public AccountController()
        {
            _context = new FoodDbContext();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                    User user = _context.Users
                                       .Where(u => u.UserId == model.UserId && u.Password == model.Password)
                                       .FirstOrDefault();
                    if (user != null)
                    {
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.UserId;
                        return RedirectToAction("Index", "Dashboard");  
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User Name or Password");
                        return View(model);
                    }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session["UserName"] = string.Empty;
            Session["UserId"] = string.Empty;
            return RedirectToAction("Login", "Account");
        }
    }
}