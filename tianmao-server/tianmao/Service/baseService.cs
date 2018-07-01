using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tianmao.Model.Domain;

namespace tianmao.Service
{
    public abstract class BaseService : IService
    {
        static BaseService()
        {
            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);

            if (String.IsNullOrEmpty(DB.ExecuteSingle("SELECT table_name FROM information_schema.TABLES WHERE table_name = 'User'")))
            {
                DB.ExecuteNonQuery(@"create table User
(
  id bigint(0) UNSIGNED NOT NULL AUTO_INCREMENT,
  password varchar(255) NULL,
  token varchar(128) NULL,
  remarks text NULL,
  PRIMARY KEY (id)
)");
            }
        }

        public virtual ResultModel Exec(QueryModel query)
        {
            ResultModel result = new ResultModel();

            var 行为 = query.SlotEntities.Where((a) => a.IntentParameterName == "行为").FirstOrDefault();
            var 参数 = query.SlotEntities.Where((a) => a.IntentParameterName == "参数").FirstOrDefault();

            if (行为 == null)
            {
                result.Reply = "好的,设备已连接，请问需要帮您做什么呢";
                result.ResultType = ResultType.ASK_INF;
                result.ExecuteCode = ExecuteCode.SUCCESS;
                result.MsgInfo = "InQuery";
            }
            else
            {
                result.Reply = "好的,正在帮您" + 行为?.SlotValue + 参数?.SlotValue;
                result.ResultType = ResultType.RESULT;
                result.ExecuteCode = ExecuteCode.SUCCESS;
                result.MsgInfo = "OK";
            }

            return result;
        }
    }
}
