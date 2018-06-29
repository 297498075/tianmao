using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using tianmao.Common;
using tianmao.Model;

namespace tianmao
{
    [Produces("application/json")]
    [Route("/token")]
    public class TokenController : Controller
    {
        static TokenController()
        {
            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);
            String exist = DB.ExecuteSingle("SELECT table_name FROM information_schema.TABLES WHERE table_name ='TokenLog'");

            if (String.IsNullOrEmpty(exist))
            {
                DB.ExecuteNonQuery(@"create table TokenLog
(
date datetime default now(),
access_token varchar(128),
refresh_token varchar(128),
userId bigint
)");
            }
        }

        [HttpPost]
        [HttpGet]
        public HttpResponseMessage Post()
        {
            byte[] buffer = Request.Body.GetAllBytes();
            String queryString = Encoding.UTF8.GetString(buffer);
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            Log.WriteLogAsync(queryString+Request.QueryString, "request");
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法

            //var redirect_uri = Request.Query["redirect_uri"].FirstOrDefault();
            //var client_id = Request.Query["client_id"].FirstOrDefault();
            //var response_type = Request.Query["response_type"].FirstOrDefault();
            //var state = Request.Query["state"].FirstOrDefault();
           
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            String access_token = Guid.NewGuid().ToString();
            String refresh_token = Guid.NewGuid().ToString();
            String resultString = JsonConvert.SerializeObject(new Token()
            {
                Access_token = access_token,
                Refresh_token = refresh_token,
                Expires_in = 17600000
            }, Formatting.Indented, jsetting);

            var dic = new Dictionary<String, Object>();
            dic.Add("access_token", access_token);
            dic.Add("refresh_token", refresh_token);
            dic.Add("userId", 111);
            DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main)
                .ExecuteNonQuery(@"Insert into TokenLog(access_token,refresh_token,userId) values(?access_token,?refresh_token,?userId)", dic);

            Log.WriteLogAsync(resultString, "response");
            byte[] by = Encoding.UTF8.GetBytes(resultString);       
            Response.Body.Write(by, 0, by.Length);
            Response.Body.Flush();
            Response.StatusCode = 200;
            Response.ContentType = "application/json";
            return null;
        }
    }
}