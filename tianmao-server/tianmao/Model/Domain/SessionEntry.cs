using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tianmao.Model.Domain
{
    public class SessionEntry
    {
        private int timeToLive;
        private int liveTime = 0;
        private long timeStamp;
        private String value;

        [JsonProperty(PropertyName = "timeToLive")]
        public int TimeToLive { get => timeToLive; set => timeToLive = value; }
        [JsonProperty(PropertyName = "liveTime")]
        public int LiveTime { get => liveTime; set => liveTime = value; }
        [JsonProperty(PropertyName = "timeStamp")]
        public long TimeStamp { get => timeStamp; set => timeStamp = value; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get => value; set => this.value = value; }
    }
}
