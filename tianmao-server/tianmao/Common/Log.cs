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

        private static readonly String log = @"insert into ProgramLog(log,address) values(?log,?address)";

        private static Dictionary<String, object> dic = new Dictionary<string, object>();

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public static async Task WriteLogAsync(String txt, String address = "")
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {
            dic.Clear();
            dic.Add("log", txt);
            dic.Add("address", address);
            DB.ExecuteNonQuery(log, dic);
        }

#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public static async Task WriteLogAsync(Stream txt,long? length, String address = "")
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {
            int len = Convert.ToInt32(length);
            byte[] buffer = txt.GetAllBytes();
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            WriteLogAsync(Encoding.UTF8.GetString(buffer), address);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
        }
    }
}
