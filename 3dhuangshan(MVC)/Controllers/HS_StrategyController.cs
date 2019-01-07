using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace _3dhuangshan_MVC_.Controllers
{
    public class HS_StrategyController : Controller
    {
        // GET: HS_Strategy
        public ActionResult Strategy()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult NewStrategy()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }

        public void StrategyBusiness(string judge) {
            if (judge == "first")
            {
                HSData.Model.Model1 mod = new HSData.Model.Model1();
                ArrayList arr = new ArrayList();
                string Arr = null;
                arr = mod.StrategySearch();
                foreach (var it in arr)
                {
                    Arr += it;
                }
                Response.Write(Arr);
                Response.End();
            }
            if (judge == "second")
            {
                int id = Convert.ToInt32(Request["id"]);
                HSData.Model.Model1 mod = new HSData.Model.Model1();
                ArrayList arr = new ArrayList();
                string Arr = null;
                Arr = mod.StrategySeachByID(id);
                string name = mod.MyUserNameGetbyID(Convert.ToInt32(Arr.Split(new char[] { '✶' })[7]));
                Arr += name;
                Response.Write(Arr);
                Response.End();
            }
        }
        [ValidateInput(false)]
        public void NewStrategyBusiness(string title, string base64, string checkArr,string contentIMG, string content,string imgArr, string show)
        {
            string str = "\"";
            HSData.Model.Model1 mod = new HSData.Model.Model1();
            int id = Convert.ToInt16(HttpContext.Session["UserID"]);
            //如果session过期则使用cookies
            if(id == 0)
            {
                id = Convert.ToInt32(HttpContext.Request.Cookies["UserID"].Value);
            }
            string result = mod.StrategyInsert(title, show, content, id, checkArr);
            decodeBase64ToImage(base64, "IMG/", show.Split(new char[] { '/' })[2]);
            if (contentIMG != "")
            {
                string[] ContentIMG = Request["contentIMG"].Split(new char[] { '|' });
                string[] ImgArr = imgArr.Split(new char[] { '|' });
                if (result == "ok" && contentIMG.Length > 0)
                {

                    for (int i = 0; i < ImgArr.Length - 1; i++)
                    {
                        decodeBase64ToImage(ContentIMG[i], "IMG/", ImgArr[i].Split(new char[] { '/' })[2]);
                    }
                }
            }
            string jsonString = "{" + str + "message" + str + ":" + str + result + str + "}";

            Response.Write(jsonString);
            Response.End();
        }

        public string decodeBase64ToImage(string dataURL, string path, string imgName)
        {
            string filename = "";//声明一个string类型的相对路径
            String base64 = dataURL.Substring(dataURL.IndexOf(",") + 1);      //将‘，’以前的多余字符串删除
            System.Drawing.Bitmap bitmap = null;//定义一个Bitmap对象，接收转换完成的图片
            try//会有异常抛出，try，catch一下
            {
                String inputStr = base64;//把纯净的Base64资源扔给inpuStr,这一步有点多余
                byte[] arr = Convert.FromBase64String(inputStr);//将纯净资源Base64转换成等效的8位无符号整形数组

                System.IO.MemoryStream ms = new System.IO.MemoryStream(arr);//转换成无法调整大小的MemoryStream对象
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);//将MemoryStream对象转换成Bitmap对象

                bitmap = bmp;
                filename = path + imgName;//所要保存的相对路径及名字
                string tmpRootDir = System.Web.HttpContext.Current.Server.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath.ToString()); //获取程序根目录 
                string imagesurl2 = tmpRootDir + filename.Replace(@"/", @"\"); //转换成绝对路径 
                bitmap.Save(imagesurl2, System.Drawing.Imaging.ImageFormat.Png);//保存到服务器路径
            }
            catch (Exception)
            {
            }
            return filename;//返回相对路径
        }
    }
}