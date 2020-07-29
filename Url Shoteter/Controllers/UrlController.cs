using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shortnr.Web.Models;
using ClassLibrary1Shortnr.Web.Business;
using System.Threading.Tasks;
using Shortnr.Web.Entities;

namespace Shortnr.Web
{
    public class UrlController : Controller
    {

        private UrlManager _urlManager;
        

        public UrlController(UrlManager urlManager)
        {
            this._urlManager = urlManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            Url url = new Url();
            return View(url);
        }

        public async Task<ActionResult> Index(Url url)
        {
            if (ModelState.IsValid)
            {
                ShortUrl shortUrl = await this._urlManager.ShortenUrl(url.LongURL, Request.UserHostAddress,
                    url.CustomSegment);
                url.ShortURL = string.Format("{0}://{1}{2}{3}", Request.Url.Scheme, Request.Url.Authority,
                    Url.Content("~"), shortUrl.Segment);

              
            }

            return View(url);

        }

        public async Task<ActionResult> Click(string segment)
        {
            string referer = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            Stat stat = await this._urlManager.Click(segment, referer, Request.UserHostAddress);
            return this.RedirectPermanent(stat.ShortUrl.LongUrl);
        }

    }
}