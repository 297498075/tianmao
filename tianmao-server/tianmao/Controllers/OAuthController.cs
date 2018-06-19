using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tianmao.Common;

namespace tianmao
{
    [Produces("application/json")]
    [Route("/oauth")]
    public class OAuthController : Controller
    {
        static OAuthController()
        {
            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);
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
        }
        [HttpPost]
        public void Post()
        {
            byte[] buffer = Request.Body.GetAllBytes();
            String queryString = Encoding.UTF8.GetString(buffer);
            Log.WriteLogAsync(queryString, "request");

            var redirect_uri = Request.Query["redirect_uri"].FirstOrDefault();
            var client_id = Request.Query["client_id"].FirstOrDefault();
            var response_type = Request.Query["response_type"].FirstOrDefault();
            var state = Request.Query["state"].FirstOrDefault();

            var dic = new Dictionary<String,Object>();
            dic.Add("redirect_uri", redirect_uri);
            dic.Add("client_id", client_id);
            dic.Add("response_type", response_type);
            dic.Add("state", state);
            DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main)
                .ExecuteNonQuery(@"Insert into OAuthLog(redirect_uri,client_id,response_type,state) values(?redirect_uri,?client_id,?response_type,?state)", dic);
        }
    }
}