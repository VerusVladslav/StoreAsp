using StoreAsp.Images.Helper;
using StoreAsp.Models;
using StoreAsp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreAsp.Areas.Manager.Controllers
{
    public class ManagerPanelController : Controller
    {

        private ApplicationDbContext _context;

        public ManagerPanelController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: Manager/ManagerPanel
        
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
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }


        [HttpPost]

        public ActionResult Create(NewViewModel model, HttpPostedFileBase imageFile)
        {

            string filename = Guid.NewGuid().ToString() + ".jpg";
            string FullPathImage = Server.MapPath(Config.NewsImagePath) + "\\" + filename;

            using (Bitmap bmp = new Bitmap(imageFile.InputStream))
            {
                Bitmap readyImage = ImageWorker.CreateImage(bmp, 450, 450);
                if (readyImage != null)
                {
                    readyImage.Save(FullPathImage, ImageFormat.Jpeg);
                    NewsModel product = new NewsModel()
                    {
                        Id=model.Id,
                        Date=model.Date,
                        Category=model.Category,
                        Name = model.Name,
                        
                        Image = filename

                    };
                    _context.News.Add(product);
                    _context.SaveChanges();
                }

            }

            return RedirectToAction("Index");
        }

       
    }
}