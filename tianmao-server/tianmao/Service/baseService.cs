using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tianmao.Model;

namespace tianmao.Service
{
    public class BaseService : IService
    {
        public virtual ResultModel Exec(QueryModel query)
        {
            Check(query);

            ResultModel result = new ResultModel();

            var 行为 = query.SlotEntities.Where((a) => a.IntentParameterName == "行为").FirstOrDefault();
            var 参数 = query.SlotEntities.Where((a) => a.IntentParameterName == "参数").FirstOrDefault();

            result.Reply = "好的,正在帮您" + 行为?.SlotValue + 参数?.SlotValue;

            SetSuccess(result);

            return result;
        }

        public virtual void SetSuccess(ResultModel result)
        {
            result.ResultType = ResultType.RESULT;
            result.ExecuteCode = ExecuteCode.SUCCESS;
            result.MsgInfo = "测试";
        }

        public virtual void Check(QueryModel query)
        {
            if (query.SlotEntities == null)
            {
                query.SlotEntities = new List<SlotEntity>();
            }
            if (query.SlotEntities.Count == 0)
            {
                query.SlotEntities.Add(new SlotEntity() { IntentParameterName = "行为", SlotValue = "查询" });
                query.SlotEntities.Add(new SlotEntity() { IntentParameterName = "参数", SlotValue = "电脑" });
            }
        }
    }
}
