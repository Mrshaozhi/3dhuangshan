using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

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
        
        public void HomeBusiness(string judge)
        {
            if (judge == "first")
            {
                HSData.Model.Model1 mod = new HSData.Model.Model1();
                int id = Convert.ToInt16(HttpContext.Session["UserID"]);
                //如果session过期则使用cookies
                if (id == 0)
                {
                    id = Convert.ToInt32(HttpContext.Request.Cookies["UserID"].Value);
                }
                ArrayList arr = new ArrayList();
                string Arr = null;
                arr = mod.UserInfo(id);
                foreach (var it in arr)
                {
                    Arr += it;
                }
                Response.Write(Arr);
                Response.End();
            }
            if(judge == "second")
            {
                HSData.Model.Model1 mod = new HSData.Model.Model1();
                int id = Convert.ToInt16(HttpContext.Session["UserID"]);
                //如果session过期则使用cookies
                if (id == 0)
                {
                    id = Convert.ToInt32(HttpContext.Request.Cookies["UserID"].Value);
                }
                string[] arr = mod.CollectByUser(id).Split(new char[] { '✶' });
                string Arr = null;
                for(int i = 0; i < arr.Length - 1; i++)
                {
                    Arr += arr[i] + "✶" + mod.StrategySeachByID(Convert.ToInt16(arr[i])) + "┇";
                }
                Response.Write(Arr);
                Response.End();

            }
        }
    }
}