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

            var 行为 = query.SlotEntities.Where((a) => a.IntentParameterName == "行为").FirstOrDefault();
            var 参数 = query.SlotEntities.Where((a) => a.IntentParameterName == "参数").FirstOrDefault();

            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);

            var SessionId = DB.ExecuteSingle("select SessionId from Session");

            if (String.IsNullOrEmpty(SessionId))
            {
                model.Reply = "目前没有电脑在线哦";
                return model;
            }

            Server.Send(行为.SlotValue,参数.SlotValue, SessionId);

            return model;
        }
    }
}
