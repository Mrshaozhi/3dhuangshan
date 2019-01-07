using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSData.Model
{
    public partial class Model1
    {
        //插入图片
        public string PhotoInsert(string name,string path,int id)
        {
            Model1 mod = new Model1();
            try
            {
                var photo = new Tb_Photo
                {
                    Photo_Name = name,
                    Photo_Path = path,
                    Photo_Check = "未审核",
                    Photo_Praise = 0,
                    Photo_UploadTime = DateTime.Now.ToLocalTime(),
                    User_ID = id,
                };
                mod.Tb_Photo.Add(photo);
                mod.SaveChanges();
                return "ok";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        //查询图片
        public ArrayList PhotoSearch()
        {
            Model1 mod = new Model1();
            var list = mod.Tb_Photo
                .Select(u => new
                {
                    path = u.Photo_Path,
                    name = u.Photo_Name,
                    user = u.User_ID,
                });
            ArrayList arr = new ArrayList();
            foreach (var it in list)
            {
                arr.Add(it.path + "✶");
                arr.Add(it.name + "✶");
                arr.Add(it.user + "✶");
                arr.Add("┇");
            }
            return arr;
        }
    }
}
