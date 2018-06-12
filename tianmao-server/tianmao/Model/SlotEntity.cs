using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tianmao.Model
{
    public class SlotEntity
    {
        private long intentParameterId;
        private String intentParameterName;
        private String originalValue;
        private String standardValue;
        private int liveTime;
        private long createTimeStamp;
        private String slotName;
        private String slotValue;

        [JsonProperty(PropertyName = "intentParameterId")]
        public long IntentParameterId { get => intentParameterId; set => intentParameterId = value; }
        [JsonProperty(PropertyName = "intentParameterName")]
        public string IntentParameterName { get => intentParameterName; set => intentParameterName = value; }
        [JsonProperty(PropertyName = "originalValue")]
        public string OriginalValue { get => originalValue; set => originalValue = value; }
        [JsonProperty(PropertyName = "standardValue")]
        public string StandardValue { get => standardValue; set => standardValue = value; }
        [JsonProperty(PropertyName = "liveTime")]
        public int LiveTime { get => liveTime; set => liveTime = value; }
        [JsonProperty(PropertyName = "createTimeStamp")]
        public long CreateTimeStamp { get => createTimeStamp; set => createTimeStamp = value; }
        [JsonProperty(PropertyName = "slotName")]
        public string SlotName { get => slotName; set => slotName = value; }
        [JsonProperty(PropertyName = "slotValue")]
        public string SlotValue { get => slotValue; set => slotValue = value; }
    }
}
