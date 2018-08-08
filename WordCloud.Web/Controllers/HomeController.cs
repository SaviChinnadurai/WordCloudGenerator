using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordCloud.Web.Models;

namespace WordCloud.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError]
        public ActionResult Index(Website website)
        {
            if (!Uri.IsWellFormedUriString(website.URL, UriKind.RelativeOrAbsolute))
            { 
                return View();
            }

            if (!(website.URL.Contains("http://") || website.URL.Contains("https://")))
            {
                website.URL = "http://" + website.URL;
            }

            return RedirectToAction("Index", "WordCloud", website);
        }
    }
}