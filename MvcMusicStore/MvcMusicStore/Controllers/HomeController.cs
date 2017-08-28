using MvcMusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        MusicStoreDB db = new MusicStoreDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "It is boring.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string q)
        {
            var albums = db.Albums.Include("Artist").Where(a => a.Title.Contains(q)).Take(10);
            return View(albums);
        }
    }
}