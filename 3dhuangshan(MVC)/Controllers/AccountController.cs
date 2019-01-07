using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _3dhuangshan_MVC_.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public void LoginBusiness(string User_Name,string User_PW)
        {
            string Name = User_Name;
            string PW = User_PW;

            HSData.Model.Model1 n = new HSData.Model.Model1();
            string compare = n.MyUserSearch(Name, PW);
            int UserID = n.MyUserIdGetbyName(Name);

            if ( compare == "OK")
            {

                HttpCookie cookieUser = new HttpCookie("User");
                cookieUser.Value = Name;
                cookieUser.Expires = DateTime.Now.AddDays(1);
                HttpContext.Response.AppendCookie(cookieUser);
                HttpCookie cookieUserID = new HttpCookie("UserID");
                cookieUserID.Value = UserID.ToString();
                cookieUserID.Expires = DateTime.Now.AddDays(1);
                HttpContext.Response.AppendCookie(cookieUserID);


                HttpContext.Session["User"] = Name;
                string User = Session["User"].ToString();
                HttpContext.Session["UserID"] = UserID;
                int userID = Convert.ToInt32(HttpContext.Session["UserID"]);


                string jsonString = "{\"message\":\"登陆成功\"}";
                Response.Write(jsonString);
                Response.End();

            }
            else if (compare == "false")
            {
                string jsonString = "{\"message\":\"密码错误,请确认密码后登陆\"}";
                Response.Write(jsonString);
                Response.End();
            }
            else
            {
                string jsonString = "{\"message\":\"用户名不存在\"}";
                Response.Write(jsonString);
                Response.End();

            }
        }

        public void RegisterBusiness(string UserName,string Email,string Password,string radio)
        {

        }
    }
}