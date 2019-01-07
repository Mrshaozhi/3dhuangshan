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
        //新建用户
        public string UserInsert(string UserName, string Email, string Password, string radio)
        {
            Model1 mod = new Model1();
            HSCommon.Crypt cr = new HSCommon.Crypt();
            string pw = cr.Encrypt(Password);
            var User = mod.Tb_User.Where(u => u.User_Name == UserName).Select(u => new { NAME = u.User_Name }).FirstOrDefault();
            try
            {
                if (!User.NAME.Any()) ;
            }
            catch (Exception)
            {
                var user = new Tb_User
                {
                    User_Name = UserName,
                    User_Email = Email,
                    User_PW = pw,
                    User_Sex = radio,
                    User_Level = 1,
                    User_RegisterTime = DateTime.Now.ToLocalTime(),
                };
                mod.Tb_User.Add(user);
                mod.SaveChanges();
                return "ok";
            }
            return "false";
        }

        //登陆验证
        public string MyUserSearch(string name, string password)
        {
            try
            {


                Model1 con = new Model1();
                var user = con.Tb_User.Where(u => u.User_Name == name).Select(u => new { PW = u.User_PW }).FirstOrDefault();
                var keyu_id = con.Tb_User.Where(u => u.User_Name == name).Select(u => new { id = u.User_ID }).FirstOrDefault();


                //对取出的密码进行解密

                HSCommon.Crypt cr = new HSCommon.Crypt();
                string s = cr.Decrypt(user.PW);

                //验证用户信息
                if (password == s)
                {
                    return "OK";
                }
                else
                {
                    return "false";
                }


            }
            catch (System.NullReferenceException)
            {
                return "NULL";
            }
        }

        //根据姓名查找ID
        public int MyUserIdGetbyName(string name)
        {
            Model1 con = new Model1();
            try
            {
                var userID = con.Tb_User.Where(u => u.User_Name == name).Select(u => new { UserID = u.User_ID }).FirstOrDefault();
                return userID.UserID;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //根据ID查找姓名
        public string MyUserNameGetbyID(int id)
        {
            Model1 con = new Model1();
            try
            {
                var Name = con.Tb_User.Where(u => u.User_ID == id).Select(u => new { name = u.User_Name }).FirstOrDefault();
                return Name.name;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
