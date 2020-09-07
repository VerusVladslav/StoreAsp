using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreAsp.Models;
using StoreAsp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreAsp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
            var Userid = User.Identity.GetUserId();//Currnet user id
            if(Userid!=null)
            {

                var User = _context.Set<IdentityUserRole>().FirstOrDefault(x => x.UserId == Userid);
                if(User!=null)
                {

                
                var role = _context.Roles.FirstOrDefault(t => t.Id == User.RoleId);
                if (role.Name == "Admin")
                {
                    return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });

                }
                if(role.Name=="User")
                    {
                        return RedirectToAction("Index", "UserPanel", new { area = "User" });
                    }
                    if (role.Name == "Manager")
                    {
                        return RedirectToAction("Index", "ManagerPanel", new { area = "Manager" });
                    }
                }
            }
            return View();
        }

      //  [Authorize(Roles ="Admin")]
      
      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}