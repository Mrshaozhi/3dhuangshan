using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace _3dhuangshan_MVC_.Controllers
{
    public class HS_PhotoController : Controller
    {
        // GET: HS_Photo
        public ActionResult Photo()
        {
            return View();
        }

        public void PhotoBusiness(string judge,string base64,string path)
        {
            if (judge == "first")
            {
                string str = "\"";
                string name = path.Split(new char[] { '/' })[2];
                HSData.Model.Model1 mod = new  HSData.Model.Model1();
                string result = mod.PhotoInsert(name, path, Convert.ToInt32(Session["UserID"]));
                if (result == "ok")
                {
                    decodeBase64ToImage(base64, "IMG/Photo/", name);
                    string jsonString = "{" + str + "message" + str + ":" + str + result + str + "}";
                    Response.Write(jsonString);
                    Response.End();
                }
                else
                {
                    string jsonString = "{" + str + "message" + str + ":" + str + result + str + "}";
                    Response.Write(jsonString);
                    Response.End();
                }
            }
            if (judge == "second")
            {
                HSData.Model.Model1 mod = new  HSData.Model.Model1();
                ArrayList arr = new ArrayList();
                string Arr = null;
                arr = mod.PhotoSearch();
                foreach (var it in arr)
                {
                    Arr += it;
                }
                Response.Write(Arr);
                Response.End();
            }
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