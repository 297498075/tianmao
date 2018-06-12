using DBCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tianmao.Common
{
    public class Log
    {
        private static IDataBase db;
        private static IDataBase DB
        {
            get
            {
                if (db == null)
                {
                    db = DataBaseFactory.GetDataBase(DataBaseType.main);

                    String exist = DB.ExecuteSingle("SELECT table_name FROM information_schema.TABLES WHERE table_name ='ProgramLog'");

                    if (String.IsNullOrEmpty(exist))
                    {
                        DB.ExecuteNonQuery(@"create table ProgramLog
(
date datetime default now(),
log text,
address varchar(255) default """"
)");
                    }
                }
                return db;
            }
        }

        private static String log = @"insert into ProgramLog(log,address) values(?log,?address)";

        private static Dictionary<String, object> dic = new Dictionary<string, object>();

        public static async Task WriteLogAsync(String txt, String address = "")
        {
            dic.Clear();
            dic.Add("log", txt);
            dic.Add("address", address);
            DB.ExecuteNonQuery(log, dic);
        }

        public static async Task WriteLogAsync(Stream txt,long? length, String address = "")
        {
            int len = Convert.ToInt32(length);
            byte[] buffer = txt.GetAllBytes();
            WriteLogAsync(Encoding.UTF8.GetString(buffer), address);
        }
    }
}
