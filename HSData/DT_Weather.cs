using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData.Model
{
    public partial class Model1
    {
        //插入历史天气
        public string WeatherInsert(string type, string windDirection, string windSpeed, string temperMin, string temperMax, DateTime Date)
        {
            Model1 mod = new Model1();
            var weather = new Tb_Weather
            {
                Weather_Type = type,
                Weather_WindDirection = windDirection,
                Weather_WindSpeed = windSpeed,
                Weather_TemperMin = temperMin,
                Weather_TemperMax = temperMax,
                Weather_Date = Date,
            };
            mod.Tb_Weather.Add(weather);
            mod.SaveChanges();
            return "ok";
        }
        //查询历史天气
        public ArrayList WeatherSearch()
        {
            Model1 mod = new Model1();
            var list = mod.Tb_Weather
                .Select(u => new
                {
                    type = u.Weather_Type,
                    windD = u.Weather_WindDirection,
                    windS = u.Weather_WindSpeed,
                    temMin = u.Weather_TemperMin,
                    temMax = u.Weather_TemperMax,
                    date = u.Weather_Date
                });
            ArrayList arr = new ArrayList();
            foreach (var it in list)
            {
                arr.Add(it.type + "*");
                arr.Add(it.windD + "*");
                arr.Add(it.windS + "*");
                arr.Add(it.temMin + "*");
                arr.Add(it.temMax + "*");
                arr.Add(it.date + "*");
                arr.Add("|");
            }
            return arr;
        }

        //删除历史天气
        public string WeatherDelet(int i)
        {
            Model1 mod = new Model1();
            var list = mod.Tb_Weather
                .Select(u => new
                {
                    id = u.Weather_ID,
                }).Take(i);
            foreach (var it in list)
            {
                var re = new Tb_Weather { Weather_ID = it.id };
                mod.Tb_Weather.Attach(re);
                mod.Tb_Weather.Remove(re);

            }
            mod.SaveChanges();
            return ("ok");
        }
    }
}
