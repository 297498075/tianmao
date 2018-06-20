﻿using System;
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
//            var DB = DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main);
//            String exist = DB.ExecuteSingle("SELECT table_name FROM information_schema.TABLES WHERE table_name ='TokenLog'");

//            if (String.IsNullOrEmpty(exist))
//            {
//                DB.ExecuteNonQuery(@"create table TokenLog
//(
//date datetime default now(),
//redirect_uri text,
//client_id varchar(128),
//response_type varchar(32),
//state varchar(32)
//)");
//            }
        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            byte[] buffer = Request.Body.GetAllBytes();
            String queryString = Encoding.UTF8.GetString(buffer);
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            Log.WriteLogAsync(queryString, "request");
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法

            //var redirect_uri = Request.Query["redirect_uri"].FirstOrDefault();
            //var client_id = Request.Query["client_id"].FirstOrDefault();
            //var response_type = Request.Query["response_type"].FirstOrDefault();
            //var state = Request.Query["state"].FirstOrDefault();

            //var dic = new Dictionary<String, Object>();
            //dic.Add("redirect_uri", redirect_uri);
            //dic.Add("client_id", client_id);
            //dic.Add("response_type", response_type);
            //dic.Add("state", state);
            //DBCommon.DataBaseFactory.GetDataBase(DBCommon.DataBaseType.main)
            //    .ExecuteNonQuery(@"Insert into OAuthLog(redirect_uri,client_id,response_type,state) values(?redirect_uri,?client_id,?response_type,?state)", dic);

            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            String resultString = JsonConvert.SerializeObject(new Token()
            {
                Access_token = "NzQ2OTI2MTUwQUZFSElORkRWUQ==",
                Refresh_token = "NzQ2OTI2MTUwQUZFSElORkRWUQ==",
                Expires_in = 17600000
            }, Formatting.Indented, jsetting);
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