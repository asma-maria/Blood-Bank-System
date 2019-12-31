using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BloodBankManagementSystem.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
    
        private BloodBankEntities db = new BloodBankEntities();
        // GET: Account
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]

        public ActionResult Login(Models.Membership model)
        {
            using (var context = new BloodBankEntities())
            {
                bool isValid = context.Users.Any(x => x.UserName == model.UserName && x.Password == model.Password && x.Email==model.Email);

                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employees");
                }
                ModelState.AddModelError("", "Invalid Username,Password and Email");
                return View();
            }

        }

        public ActionResult Signup()
        {
            return View();

        }
        [HttpPost]

        public ActionResult Signup(User model)
        {
            using (var context = new BloodBankEntities())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        
    }
}