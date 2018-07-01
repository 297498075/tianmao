using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tianmao.Common;
using tianmao.Model.Domain;
using tianmao.Model.Entry;

namespace tianmao.Service
{
    public class UseService : BaseService
    {
        public override ResultModel Exec(QueryModel query)
        {
            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);

            var model = base.Exec(query);

            if (String.IsNullOrEmpty(query.Token))
            {
                model.Reply = "此设备还未授权，不能进行此操作哦！";
                return model;
            }

            var dic = new Dictionary<String, Object>
            {
                { "token", query.Token }
            };
            User user = DB.ExecuteReader<User>("select * from User where token=?token", dic)?.FirstOrDefault();

            if(user == null)
            {
                model.Reply = "没有找到你的用户信息哦";
                return model;
            }

            var 行为 = query.SlotEntities.Where((a) => a.IntentParameterName == "行为").FirstOrDefault();
            var 参数 = query.SlotEntities.Where((a) => a.IntentParameterName == "参数").FirstOrDefault();

            bool ok = Server.Send(行为.SlotValue, 参数.SlotValue, user.Id);

            if (!ok)
            {
                model.Reply = "您还没有打开电脑客户端哦";
                return model;
            }

            return model;
        }
    }
}
