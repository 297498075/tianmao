using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tianmao_client.Service
{
    public class SessionService : BaseService
    {
        public override bool Exec(string query)
        {
            var dic = new Dictionary<String, Object>();
            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);
            dic.Add("Id",new MySqlParameter("Id",query));
            DB.ExecuteNonQuery("update Session set SessionId=?Id", dic);
            return true;
        }
    }
}
