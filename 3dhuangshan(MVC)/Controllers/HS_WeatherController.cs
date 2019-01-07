using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;

namespace _3dhuangshan_MVC_.Controllers
{
    public class HS_WeatherController : Controller
    {
        // GET: HS_Weather
        public ActionResult Weather()
        {
            return View();
        }
        public void WeatherBusiness(string weather,string winD, string winS, string temMin,string temMax,string date,  string judge)
        {
            if (judge == "first")
            {
                string[] WinD = Request["winD"].Split(new char[] { '|' });
                string[] WinS = Request["winS"].Split(new char[] { '|' });
                string[] TemMin = Request["temMin"].Split(new char[] { '|' });
                string[] TemMax = Request["temMax"].Split(new char[] { '|' });
                string[] Weather = Request["weather"].Split(new char[] { '|' });
                string[] Date = Request["date"].Split(new char[] { '|' });
                HSData.Model.Model1 mod = new HSData.Model.Model1();
                ArrayList arr = new ArrayList();
                string Arr = null;
                arr = mod.WeatherSearch();
                foreach (var it in arr)
                {
                    Arr += it;
                }
                if (Arr == null)        //当数据库为空插入三天天气
                {
                    mod.WeatherInsert(Weather[0], WinD[0], WinS[0], TemMin[0], TemMax[0], Convert.ToDateTime(Date[0]));
                    mod.WeatherInsert(Weather[1], WinD[1], WinS[1], TemMin[1], TemMax[1], Convert.ToDateTime(Date[1]));
                    mod.WeatherInsert(Weather[2], WinD[2], WinS[0], TemMin[2], TemMax[2], Convert.ToDateTime(Date[2]));
                }
                string[] Row = Arr.Split(new char[] { '|' });    //获取所有历史天数数据
                string[] row_1 = Row[Row.Length - 2].Split(new char[] { '*' });//获取最后（最新）一天数据
                string[] row_2 = Row[Row.Length - 3].Split(new char[] { '*' });//获取倒数第二天数据
                string[] row_3 = Row[Row.Length - 4].Split(new char[] { '*' });//获取倒数第三天天数据
                DateTime now = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                DateTime day_1 = Convert.ToDateTime(row_1[5]);
                DateTime day_2 = Convert.ToDateTime(row_2[5]);
                DateTime day_3 = Convert.ToDateTime(row_3[5]);
                int compNum_1 = DateTime.Compare(now, day_1);
                int compNum_2 = DateTime.Compare(now, day_2);
                int compNum_3 = DateTime.Compare(now, day_3);
                //now> day
                if (compNum_1 > 0)
                {
                    mod.WeatherInsert(Weather[0], WinD[0], WinS[0], TemMin[0], TemMax[0], Convert.ToDateTime(Date[0]));
                    mod.WeatherInsert(Weather[1], WinD[1], WinS[1], TemMin[1], TemMax[1], Convert.ToDateTime(Date[1]));
                    mod.WeatherInsert(Weather[2], WinD[2], WinS[0], TemMin[2], TemMax[2], Convert.ToDateTime(Date[2]));
                }
                else if (compNum_2 > 0)
                {
                    mod.WeatherInsert(Weather[1], WinD[1], WinS[1], TemMin[1], TemMax[1], Convert.ToDateTime(Date[1]));
                    mod.WeatherInsert(Weather[2], WinD[2], WinS[0], TemMin[2], TemMax[2], Convert.ToDateTime(Date[2]));
                }
                else if (compNum_3 > 0)
                {
                    mod.WeatherInsert(Weather[2], WinD[2], WinS[0], TemMin[2], TemMax[2], Convert.ToDateTime(Date[2]));
                }
                if (Row.Length > 31)
                {
                    mod.WeatherDelet(Row.Length - 31);
                }
            }
            
        }
        public void WeatherBusiness2(string judge)
        {
            string str = "\"";
            //获取历史数据
            if (judge == "second")
            {
                string TYPE = null;
                string WindD = null;
                string WindS = null;
                string TemMin = null;
                string TemMax = null;
                string Date = null;
                HSData.Model.Model1 mod = new HSData.Model.Model1();
                ArrayList arr = new ArrayList();
                string Arr = null;
                arr = mod.WeatherSearch();
                foreach (var it in arr)
                {
                    Arr += it;
                }
                string[] Row = Arr.Split(new char[] { '|' });    //获取所有历史天数数据
                for (int i = 0; i < Row.Length - 1; i++)
                {
                    TYPE += Row[i].Split(new char[] { '*' })[0] + "*";
                    WindD += Row[i].Split(new char[] { '*' })[1] + "*";
                    WindS += Row[i].Split(new char[] { '*' })[2] + "*";
                    TemMin += Row[i].Split(new char[] { '*' })[3] + "*";
                    TemMax += Row[i].Split(new char[] { '*' })[4] + "*";
                    Date += Convert.ToDateTime(Row[i].Split(new char[] { '*' })[5]).ToShortDateString() + "*";
                }
                string jsonString = "{" + str + "TYPE" + str + ":" + str + TYPE + str + "," + str + "WindD" + str + ":" + str + WindD + str + "," + str + "WindS" + str + ":" + str + WindS + str + "," + str + "TemMin" + str + ":" + str + TemMin + str + "," + str + "TemMax" + str + ":" + str + TemMax + str + "," + str + "TYPE" + str + ":" + str + TYPE + str + "," + str + "Date" + str + ":" + str + Date + str + "}";
                Response.Write(jsonString);
                Response.End();
            }
        }
    }
}