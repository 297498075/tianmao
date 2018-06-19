using System;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using tianmao.Common;
using tianmao.Model;
using tianmao.Service;

namespace tianmao.Controllers
{
    [Produces("application/json")]
    [Route("tianmao")]
    public class TianmaoController : Controller
    {
        public IService service;

        [HttpPost]
        public HttpResponseMessage Post()
        {
            byte[] buffer = Request.Body.GetAllBytes();
            String queryString = Encoding.UTF8.GetString(buffer);
            Log.WriteLogAsync(queryString, "request");

            QueryModel query = Convert(queryString);

            if (query == null) { return WriteError(Response,ErrorModel); }

            service = SelectService(query);

            if (service == null) { return WriteError(Response, ErrorModel); }

            ResultModel result = null;

            try
            {
                result = service.Exec(query);
            }
            catch (Exception e)
            {
                Log.WriteLogAsync(e.Message, service.GetType().Name);
                return WriteError(Response, ErrorModel);
            }
            ResponseModel<ResultModel> model = new ResponseModel<ResultModel>();
            model.ReturnCode = "0";
            model.ReturnValue = result;


            String resultString = JsonConvert.SerializeObject(model);
            Log.WriteLogAsync(resultString, "response");
            byte[] by = Encoding.UTF8.GetBytes(resultString);
            Response.Body.Write(by, 0, by.Length);
            Response.Body.Flush();
            return null;
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
                Log.WriteLogAsync("value==null", "Convert");
                return null;
            }
            QueryModel query = null;
            try
            {
                query = JsonConvert.DeserializeObject<QueryModel>(value);
            }
            catch (Exception e)
            {
                Log.WriteLogAsync("解析请求值错误:" + value, e.Message);
                return null;
            }

            if (query == null || query.SessionId == null)
            {
                Log.WriteLogAsync("query为空:" + value);
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

        public HttpResponseMessage WriteError(HttpResponse Response, byte[] resultString)
        {
            Response.Body.Write(resultString, 0, resultString.Length);
            Response.Body.Flush();
            return null;
        }
    }
}