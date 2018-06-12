using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tianmao.Model
{
    public class ResponseModel<T>
    {
        private String returnCode = "0";
        private String returnErrorSolution = "";
        private String returnMessage = "";
        private T returnValue;
        
        [JsonProperty(PropertyName = "returnCode")]
        public string ReturnCode { get => returnCode; set => returnCode = value; }
        [JsonProperty(PropertyName = "returnErrorSolution")]
        public string ReturnErrorSolution { get => returnErrorSolution; set => returnErrorSolution = value; }
        [JsonProperty(PropertyName = "returnMessage")]
        public string ReturnMessage { get => returnMessage; set => returnMessage = value; }
        [JsonProperty(PropertyName = "returnValue")]
        public T ReturnValue { get => returnValue; set => returnValue = value; }
    }
}
