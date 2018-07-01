using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace tianmao.Model.Domain
{
    public class ConversationRecord
    {
        private long botId;
        private String userInputUtterance;
        private String replyUtterance;
        private long domainId;
        private long intentId;
        private String intentName;
        private long timestamp;
        private ResultType resultType;
        private List<SlotEntity> slotEntities;

        [JsonProperty(PropertyName = "botId")]
        public long BotId { get => botId; set => botId = value; }

        [JsonProperty(PropertyName = "userInputUtterance")]
        public string UserInputUtterance { get => userInputUtterance; set => userInputUtterance = value; }
        [JsonProperty(PropertyName = "replyUtterance")]
        public string ReplyUtterance { get => replyUtterance; set => replyUtterance = value; }
        [JsonProperty(PropertyName = "domainId")]
        public long DomainId { get => domainId; set => domainId = value; }
        [JsonProperty(PropertyName = "intentId")]
        public long IntentId { get => intentId; set => intentId = value; }
        [JsonProperty(PropertyName = "intentId")]
        public string IntentName { get => intentName; set => intentName = value; }
        [JsonProperty(PropertyName = "timestamp")]
        public long Timestamp { get => timestamp; set => timestamp = value; }
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "resultType")]
        public ResultType ResultType { get => resultType; set => resultType = value; }
        [JsonProperty(PropertyName = "slotEntities")]
        public List<SlotEntity> SlotEntities { get => slotEntities; set => slotEntities = value; }
    }
}
