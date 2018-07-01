using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tianmao.Model.Entry
{
    public class User
    {
        
        private String id;
        private String password;
        private String token;
        private String remarks;
        
        [JsonProperty(PropertyName = "id")]
        public string Id { get => id; set => id = value; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get => password; set => password = value; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get => token; set => token = value; }
        [JsonProperty(PropertyName = "remarks")]
        public string Remarks { get => remarks; set => remarks = value; }
    }
}
