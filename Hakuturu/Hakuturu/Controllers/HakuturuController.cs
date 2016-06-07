using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hakuturu.Controllers
{
    public class HakuturuController : Controller
    {
        // GET: Hakuturu
        public ActionResult Index()
        {
            return View();
        }

        public string Login(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + " ID:" + ID);
        }
    }
}