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
            return View();
        }

      //  [Authorize(Roles ="Admin")]
      
        public ActionResult Admin()
        {
          //  ViewBag.Users= GetUsers();
            ViewBag.Roles = GetRoles();

            var users = GetUsers();
            var roles = GetRoles();

            var userroles = new List<UserRolesViewModel>(); 
                foreach (var item in users)
                {
                    var user = new UserRolesViewModel()
                    {
                        User = item.Username,
                        Role = roles.FirstOrDefault(x => x.Id == item.IdROle).Role
                    };
                    userroles.Add(user);
                }
           
           




            return View(userroles);
        }

        public List<UserViewModel> GetUsers()
        {
            List<UserViewModel> users = new List<UserViewModel>();

            foreach (var item in _context.Users.ToList())
            {

                var role = _context.Set<IdentityUserRole>().FirstOrDefault(x => x.UserId == item.Id);
                if (role != null)
                {

                users.Add(new UserViewModel
                {
                    Username = item.Email,
                    IdROle = role.RoleId
                
                });
                }
                else
                {
                    users.Add(new UserViewModel
                    {
                        Username = item.Email,


                        IdROle = "No Role"

                    });
                }
            }
            return users;


        }
        public List<RolesViewModel> GetRoles()
        {
            List<RolesViewModel> roles = new List<RolesViewModel>();

            foreach (var item in _context.Roles.ToList())
            {

                roles.Add(new RolesViewModel
                {
                    Id = item.Id,
                    Role = item.Name
                });
            }
            return roles;


        }

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