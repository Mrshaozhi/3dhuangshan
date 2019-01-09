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
        //插入攻略
        public string StrategyInsert(string title, string show, string content, int userID, string check)
        {
            Model1 mod = new Model1();
            try
            {
                var strategy = new Tb_Strategy
                {
                    Strategy_Title = title,
                    Strategy_ShowPhoto = show,
                    Strategy_Content = content,
                    Strategy_Check = "未审核|" + check,
                    Strategy_PublishTime = DateTime.Now,
                    User_ID = userID,
                    Strategy_Click = 0,
                    Strategy_Praise = 0,
                };
                mod.Tb_Strategy.Add(strategy);
                mod.SaveChanges();
                return "ok";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        //查询攻略
        public ArrayList StrategySearch()
        {
            Model1 mod = new Model1();
            var list = mod.Tb_Strategy
                .Select(u => new
                {
                    id = u.Strategy_ID,
                    title = u.Strategy_Title,
                    show = u.Strategy_ShowPhoto,
                    content = u.Strategy_Content,
                    check = u.Strategy_Check,
                    time = u.Strategy_PublishTime,
                    praise = u.Strategy_Praise,
                    click = u.Strategy_Click,
                    user = u.User_ID,
                });
            ArrayList arr = new ArrayList();
            foreach (var it in list)
            {
                arr.Add(it.id + "✶");
                arr.Add(it.title + "✶");
                arr.Add(it.show + "✶");
                arr.Add(it.content + "✶");
                arr.Add(it.check + "✶");
                arr.Add(it.time + "✶");
                arr.Add(it.praise + "✶");
                arr.Add(it.click + "✶");
                arr.Add(it.user + "✶");
                arr.Add("┇");
            }
            return arr;
        }

        //根据ID查询攻略
        public string StrategySeachByID(int id)
        {
            Model1 con = new Model1();
            try
            {
                var arr = con.Tb_Strategy
                    .Where(u => u.Strategy_ID == id).Select(u => new {
                        title = u.Strategy_Title,
                        show = u.Strategy_ShowPhoto,
                        content = u.Strategy_Content,
                        check = u.Strategy_Check,
                        time = u.Strategy_PublishTime.ToString(),
                        praise = u.Strategy_Praise,
                        click = u.Strategy_Click,
                        user = u.User_ID
                    }).FirstOrDefault();
                string Arr = arr.title + "✶" + arr.show + "✶" + arr.content + "✶" + arr.check + "✶" + arr.time.ToString() + "✶" + arr.praise.ToString() + "✶" + arr.click.ToString() + "✶" + arr.user.ToString() + "✶";
                return Arr;
            }
            catch (Exception)
            {
                return "";
            }
        }

        //更新攻略审核状态
        public void StrategyCheckUpdata(int id, string check)
        {
            Model1 mod = new Model1();
            var strategy = new Tb_Strategy
            {
                Strategy_ID = id,
                Strategy_Check = check,
            };
            mod.Tb_Strategy.Attach(strategy);
            var setEntry = ((IObjectContextAdapter)mod).ObjectContext.ObjectStateManager.GetObjectStateEntry(strategy);
            setEntry.SetModifiedProperty("Strategy_Check");
            mod.SaveChanges();
        }

        //更新攻略浏览量
        public void StrategyClickUpdata(int id)
        {
            Model1 mod = new Model1();
            var info = mod.Tb_Strategy.Where(u => u.Strategy_ID == id).Select(u => new { num = u.Strategy_Click }).FirstOrDefault();
            var strategy = new Tb_Strategy
            {
                Strategy_ID = id,
                Strategy_Click = info.num + 1
            };
            mod.Tb_Strategy.Attach(strategy);
            var setEntry = ((IObjectContextAdapter)mod).ObjectContext.ObjectStateManager.GetObjectStateEntry(strategy);
            setEntry.SetModifiedProperty("Strategy_Click");
            mod.SaveChanges();
        }

        //更新攻略点赞数
        public void StrategyPraiseUpdata(int id, int praise)
        {
            Model1 mod = new Model1();
            var strategy = new Tb_Strategy
            {
                Strategy_ID = id,
                Strategy_Praise = praise,
            };
            mod.Tb_Strategy.Attach(strategy);
            var setEntry = ((IObjectContextAdapter)mod).ObjectContext.ObjectStateManager.GetObjectStateEntry(strategy);
            setEntry.SetModifiedProperty("Strategy_Praise");
            mod.SaveChanges();
        }

    }
}
