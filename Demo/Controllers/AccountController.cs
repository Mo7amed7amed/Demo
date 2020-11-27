using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        ITIModel db = new ITIModel();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                Student std = db.Students.FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
                if (std != null)
                {
                    Session["isAuthinticated"] = true;
                    return Redirect(returnurl);
                    // return Content($"user: {model.Email} ");
                }
                else
                {
                    ModelState.AddModelError("", "email and password not correct");
                }
            }
            return View(model);
        }

    }
}