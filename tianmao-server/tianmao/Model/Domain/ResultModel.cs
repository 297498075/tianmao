using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace tianmao.Model.Domain
{
    public class ResultModel
    {
        private String reply;
        private ResultType resultType;
        private List<AskedInfoMsg> askedInfos;
        private Dictionary<String, String> properties;
        private Dictionary<String, SessionEntry> sessionEntries;
        private ExecuteCode executeCode;
        private String msgInfo;
        private List<Action> actions;

        [JsonProperty(PropertyName = "reply")]
        public string Reply { get => reply; set => reply = value; }
        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, string> Properties { get => properties; set => properties = value; }
        [JsonProperty(PropertyName = "msgInfo")]
        public string MsgInfo { get => msgInfo; set => msgInfo = value; }
        [JsonProperty(PropertyName = "actions")]
        public List<Action> Actions { get => actions; set => actions = value; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resultType")]
        public ResultType ResultType { get => resultType; set => resultType = value; }
        [JsonProperty(PropertyName = "askedInfos")]
        public List<AskedInfoMsg> AskedInfos { get => askedInfos; set => askedInfos = value; }
        [JsonProperty(PropertyName = "sessionEntries")]
        public Dictionary<string, SessionEntry> SessionEntries { get => sessionEntries; set => sessionEntries = value; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "executeCode")]
        public ExecuteCode ExecuteCode { get => executeCode; set => executeCode = value; }
    }
}
