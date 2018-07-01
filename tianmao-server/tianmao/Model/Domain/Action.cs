using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;

namespace tianmao.Model.Domain
{
    public class Action
    {
        private String name;
        private Dictionary<String, String> properties;

        [JsonProperty(PropertyName="name")]
        public string Name { get => name; set => name = value; }

        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, string> Properties { get => properties; set => properties = value; }
    }
}
