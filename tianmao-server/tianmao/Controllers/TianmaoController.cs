using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using tianmao.Common;
using tianmao.Model.Domain;
using tianmao.Service;

namespace tianmao.Controllers
{
    [Produces("application/json")]
    [Route("/tianmao")]
    public class TianmaoController : Controller
    {
        public IService service;

        [HttpPost]
        public void Post()
        {
            byte[] buffer = Request.Body.GetAllBytes();
            String queryString = Encoding.UTF8.GetString(buffer);
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            Log.WriteLogAsync(queryString, "request");
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法

            QueryModel query = Convert(queryString);

            if (query == null) { WriteError(Response,ErrorModel); }

            service = SelectService(query);

            if (service == null) { WriteError(Response, ErrorModel); }

            ResultModel result = null;

            try
            {
                result = service.Exec(query);
            }
            catch (Exception e)
            {
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                Log.WriteLogAsync(e.Message, service.GetType().Name);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                WriteError(Response, ErrorModel);
            }
            ResponseModel<ResultModel> model = new ResponseModel<ResultModel>
            {
                ReturnCode = "0",
                ReturnValue = result
            };


            String resultString = JsonConvert.SerializeObject(model);
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            Log.WriteLogAsync(resultString, "response");
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
            byte[] by = Encoding.UTF8.GetBytes(resultString);
            Response.ContentLength = by.Length;
            Response.Body.Write(by, 0, by.Length);
            Response.Body.Flush();
        }

        private IService SelectService(QueryModel query)
        {
            if (query?.SlotEntities?.Count == 0)
            {
                query.SlotEntities.Add(new SlotEntity() { SlotValue = "查询" });
                query.SlotEntities.Add(new SlotEntity() { SlotValue = "电脑" });
            }
            if (query?.IntentName == "使用")
            {
                return new UseService();
            }

            return new ExceptionService();
        }

        private QueryModel Convert(String value)
        {
            if (value == null)
            {
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                Log.WriteLogAsync("value==null", "Convert");
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                return null;
            }
            QueryModel query = null;
            try
            {
                query = JsonConvert.DeserializeObject<QueryModel>(value);
            }
            catch (Exception e)
            {
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                Log.WriteLogAsync("解析请求值错误:" + value, e.Message);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                return null;
            }

            if (query == null || query.SessionId == null)
            {
#pragma warning disable CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                Log.WriteLogAsync("query为空:" + value);
#pragma warning restore CS4014 // 由于此调用不会等待，因此在调用完成前将继续执行当前方法
                return null;
            }
            return query;
        }

        private static String errorModel;

        public byte[] ErrorModel
        {
            get
            {
                if (errorModel == null)
                {
                    ResponseModel<ResultModel> model = new ResponseModel<ResultModel>()
                    {
                        ReturnCode = "0",
                        ReturnErrorSolution = "",
                        ReturnMessage = "",
                        ReturnValue = new ResultModel()
                        {
                            Actions = null,
                            AskedInfos = null,
                            ExecuteCode = ExecuteCode.SUCCESS,
                            MsgInfo = "测试",
                            Properties = null,
                            Reply = "哈哈哈,异常了!!!",
                            ResultType = ResultType.RESULT,
                            SessionEntries = null
                        }
                    };
                    errorModel = JsonConvert.SerializeObject(model);
                }
                return Encoding.UTF8.GetBytes(errorModel);
            }
        }

        public ActionResult WriteError(HttpResponse Response, byte[] resultString)
        {
            Response.ContentLength = resultString.Length;
            Response.Body.Write(resultString, 0, resultString.Length);
            Response.Body.Flush();
            return null;
        }
    }
}