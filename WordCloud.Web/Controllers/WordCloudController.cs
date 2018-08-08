using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordCloud.Core;
using WordCloud.Web.Models;

namespace WordCloud.Web.Controllers
{
    public class WordCloudController : Controller
    {
        // GET: WordCloud
        [HttpGet]
        public ActionResult Index(Website website)
        {
            if(website == null || string.IsNullOrEmpty(website.URL) )
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
            }

            try
            {
                var wcService = new WebParserService();

                var wcList = wcService.Parse(website.URL);
                List<string> wordList = wcList.Select(m => m.WordText).ToList();
                List<int> countList = wcList.Select(m => m.Count).ToList();

                var wc = new WordCloud(800, 800);
                Image wcImage = wc.Draw(wordList, countList);

                byte[] imageByteData = imageToByteArray(wcImage);
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                ViewBag.ImageData = imageDataURL;

                return View();
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

        }


        private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
    }
}