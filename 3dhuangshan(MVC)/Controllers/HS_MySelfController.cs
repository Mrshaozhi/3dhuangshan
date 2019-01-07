using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3dhuangshan_MVC_.Controllers
{
    public class HS_MySelfController : Controller
    {
        // GET: HS_MySelf
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Calendar()
        {
            return View();
        }
    }
}