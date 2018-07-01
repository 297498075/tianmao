using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tianmao.Model.Domain
{
    public class AskedInfoMsg
    {
        private String parameterName;
        private long intentId;

        [JsonProperty(PropertyName = "parameterName")]
        public string ParameterName { get => parameterName; set => parameterName = value; }

        [JsonProperty(PropertyName = "intentId")]
        public long IntentId { get => intentId; set => intentId = value; }
    }
}
