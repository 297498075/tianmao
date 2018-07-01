using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace tianmao.Model.Domain
{
    public class QueryModel
    {
        private String sessionId;
        private String utterance;
        private long skillId;
        private String skillName;
        private String token;
        private long intentId;
        private String intentName;
        private Dictionary<String, String> requestData = null;
        private List<SlotEntity> slotEntities = null;
        private List<ConversationRecord> conversationRecords = null;
        private Dictionary<String, SessionEntry> sessionEntries;
        private long botId;
        private long domainId;

        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get => sessionId; set => sessionId = value; }
        [JsonProperty(PropertyName = "utterance")]
        public string Utterance { get => utterance; set => utterance = value; }
        [JsonProperty(PropertyName = "skillId")]
        public long SkillId { get => skillId; set => skillId = value; }
        [JsonProperty(PropertyName = "skillName")]
        public string SkillName { get => skillName; set => skillName = value; }
        [JsonProperty(PropertyName = "intentId")]
        public long IntentId { get => intentId; set => intentId = value; }
        [JsonProperty(PropertyName = "intentName")]
        public string IntentName { get => intentName; set => intentName = value; }
        [JsonProperty(PropertyName = "requestData")]
        public Dictionary<string, string> RequestData { get => requestData; set => requestData = value; }
        [JsonProperty(PropertyName = "botId")]
        public long BotId { get => botId; set => botId = value; }
        [JsonProperty(PropertyName = "domainId")]
        public long DomainId { get => domainId; set => domainId = value; }
        [JsonProperty(PropertyName = "slotEntities")]
        public List<SlotEntity> SlotEntities { get => slotEntities; set => slotEntities = value; }
        [JsonProperty(PropertyName = "conversationRecords")]
        public List<ConversationRecord> ConversationRecords { get => conversationRecords; set => conversationRecords = value; }
        [JsonProperty(PropertyName = "sessionEntries")]
        public Dictionary<string, SessionEntry> SessionEntries { get => sessionEntries; set => sessionEntries = value; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get => token; set => token = value; }
    }
}
