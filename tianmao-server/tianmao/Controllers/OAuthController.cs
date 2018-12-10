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

namespace tianmao
{
    [Produces("application/json")]
    [Route("/oauth")]
    public class OAuthController : Controller
    {
        private static byte[] htmlPage;
        private static IDBCommon.IDataBase DB;
        static OAuthController()
        {
            DB = DBCommon.PostgreSQL.PostgreSQL.GetDataBase();
            String exist = DB.ExecuteSingle("SELECT table_name FROM information_schema.TABLES WHERE table_name ='OAuthLog'");

            if (String.IsNullOrEmpty(exist))
            {
                DB.ExecuteNonQuery(@"create table OAuthLog
(
date datetime default now(),
redirect_uri text,
client_id varchar(128),
response_type varchar(32),
state varchar(32)
)");
            }
            using (FileStream fs = new FileStream("oauth.html", FileMode.Open))
            {
                htmlPage = new byte[fs.Length];
                fs.Read(htmlPage, 0, Convert.ToInt32(fs.Length));
            }
        }
        [HttpPost]
        [HttpGet]
        public HttpResponseMessage Post()
        {
            byte[] buffer = Request.Body.GetAllBytes();
            String queryString = Encoding.UTF8.GetString(buffer);
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            Log.WriteLogAsync(queryString, "request");
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法

            var redirect_uri = Request.Query["redirect_uri"].FirstOrDefault();
            var client_id = Request.Query["client_id"].FirstOrDefault();
            var response_type = Request.Query["response_type"].FirstOrDefault();
            var state = Request.Query["state"].FirstOrDefault();

            var dic = new Dictionary<String, Object>
            {
                { "redirect_uri", redirect_uri },
                { "client_id", client_id },
                { "response_type", response_type },
                { "state", state }
            };
            DB.ExecuteNonQuery(@"Insert into OAuthLog(redirect_uri,client_id,response_type,state) values(@redirect_uri,@client_id,@response_type,@state)", dic);

            Response.ContentType = "text/html;charset=UTF-8";
            Response.Body.Write(htmlPage, 0, htmlPage.Length);
            Response.Body.Flush();
            return null;
        }
    }
}