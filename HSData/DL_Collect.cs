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
        //添加一条收藏
        public string  CollectInsert(int userId,int strategyId)
        {
            Model1 mod = new Model1();
            var info = mod.Rl_Collect.Where(u => u.User_ID == userId && u.Strategy_ID == strategyId ).Select(u => new { ID = u.Collect_ID }).FirstOrDefault();
            if (info == null)
            {
                var collect = new Rl_Collect
                {
                    User_ID = userId,
                    Strategy_ID = strategyId
                };
                mod.Rl_Collect.Add(collect);
                mod.SaveChanges();
                return "ok";
            }
            else
                return "false";
        }

        //删除一条收藏
        public string CollectDelet(int userId, int strategyId)
        {
            Model1 mod = new Model1();
            var info = mod.Rl_Collect.Where(u => u.User_ID == userId && u.Strategy_ID == strategyId).Select(u => new { ID = u.Collect_ID }).FirstOrDefault();
            if (info != null)
            {
                var re = new Rl_Collect { Collect_ID = info.ID };
                mod.Rl_Collect.Attach(re);
                mod.Rl_Collect.Remove(re);
                mod.SaveChanges();
                return "ok";
            }
            else
                return "false";
        }

        //查询用户是否收藏
        public string CollectProof(int userId, int strategyId)
        {
            Model1 mod = new Model1();
            var info = mod.Rl_Collect.Where(u => u.User_ID == userId && u.Strategy_ID == strategyId).Select(u => new { ID = u.Collect_ID }).FirstOrDefault();
            if (info != null)
            {
                return "ok";
            }
            else
                return "false";
        }

        //查询文章收藏总数
        public int CollectSearch(int strategyId)
        {
            Model1 mod = new Model1();
            var info = mod.Rl_Collect.Where(u => u.Strategy_ID == strategyId).Select(u => new { ID = u.Collect_ID }).Count();
            return info;
        }

        //查询用户收藏
        public string CollectByUser(int userId)
        {
            Model1 mod = new Model1();
            var info = mod.Rl_Collect
                .Where(u => u.User_ID == userId).Select(u => new
                {
                    id = u.Strategy_ID
                });
            string arr = null;
            foreach(var it in info)
            {
                arr += it.id.ToString() + "✶";
            }
            return arr;
        }
}
}
