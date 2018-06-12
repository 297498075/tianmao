using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tianmao.Common;
using tianmao.Model;

namespace tianmao.Service
{
    public class UseService : BaseService
    {
        public override ResultModel Exec(QueryModel query)
        {
            var model =  base.Exec(query);

            var 参数 = FindSlotEntity(query, "参数");
            var 行为 = FindSlotEntity(query, "行为");

            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);

            var SessionId = DB.ExecuteSingle("select SessionId from Session");

            if (String.IsNullOrEmpty(SessionId))
            {
                model.Reply = "目前没有电脑在线哦";
                return model;
            }

            Server.Send(行为 + ":" + 参数 + ";", SessionId);

            return model;
        }
    }
}
