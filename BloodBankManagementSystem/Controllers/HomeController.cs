using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBankManagementSystem;

namespace BloodBankManagementSystem.Controllers
{
    
    public class HomeController : Controller
    {
        BloodBankEntities bb = new BloodBankEntities();
        // GET: Home
       
        public ActionResult getUserList()
        {
            var user = bb.Users.ToList();
            return View(user);
        }
        // GET: Home
       [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contacts()
        {
            return View();
        }
        
    }
}