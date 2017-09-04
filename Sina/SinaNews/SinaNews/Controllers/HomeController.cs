using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinaNews.Models;
using System.Configuration;
using PagedList;

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

        public ActionResult SearchResult(string q,int? page)
        {
            ViewBag.searchString = q??"";
            var news = from s in db.News where s.Title.Contains(q) select s ;
            ViewBag.newsCount = news.Count().ToString();
            int pageNumber = page ?? 1;
            int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
            news = news.OrderByDescending(a => a.time);
            IPagedList<News> pagedlist = news.ToPagedList(pageNumber, pageSize);
            return View(pagedlist);
        }

        private List<News> GetNews(string searchString)
        {
            return db.News.Where(a => a.Title.Contains(searchString)).ToList();
        }
    }
}