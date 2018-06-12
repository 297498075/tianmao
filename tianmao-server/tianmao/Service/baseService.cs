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

            var 参数1 = FindSlotEntity(query,"参数1");
            var 行为 = FindSlotEntity(query, "行为");

            result.Reply = "好的,正在帮您" + 参数1.SlotValue + 行为.SlotValue;

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
                query.SlotEntities.Add(new SlotEntity() { SlotValue = "查询" });
                query.SlotEntities.Add(new SlotEntity() { SlotValue = "电脑" });
            }
        }

        public SlotEntity FindSlotEntity(QueryModel model, String SlotEntityName,int index = 0)
        {
            for(int i = 0; i < model.SlotEntities.Count; i++)
            {
                if(model.SlotEntities[i].IntentParameterName == SlotEntityName)
                {
                    return model.SlotEntities[i];
                }
            }

            return null;
        }
    }
}
