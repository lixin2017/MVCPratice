using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinaNews.Models;

namespace SinaNews.Controllers
{
    public class HomeController : Controller
    {
        private SinaNewsContext db = new SinaNewsContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return PartialView();
        }

        public ActionResult SearchResult(string q)
        {
            var News = GetNews(q);
            return PartialView(News);
        }

        private List<News> GetNews(string searchString)
        {
            return db.News.Where(a => a.Title.Contains(searchString)).ToList();
        }
    }
}