using StoreAsp.Models;
using StoreAsp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreAsp.Areas.User.Controllers
{
    public class UserPanelController : Controller
    {
        private ApplicationDbContext _context;

        public UserPanelController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: User/UserPanel
        public ActionResult Index()
        {
            List<NewViewModel> news = new List<NewViewModel>();
            foreach (var item in _context.News.ToList())
            {
                news.Add(new NewViewModel
                {
                    Id = item.Id,
                    Category = item.Category,
                    Date = item.Date,
                    Image = item.Image,
                    Name = item.Name,
                    Text = item.Text
                });
            }

            return View(news);
        }
    }
}