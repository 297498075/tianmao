using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tianmao.Model
{
    public class Token
    {
        private String access_token;
        private String refresh_token;
        private long expires_in;
        private String error;
        private String error_description;

        [JsonProperty(PropertyName = "access_token")]
        public string Access_token { get => access_token; set => access_token = value; }
        [JsonProperty(PropertyName = "refresh_token")]
        public string Refresh_token { get => refresh_token; set => refresh_token = value; }
        [JsonProperty(PropertyName = "expires_in")]
        public long Expires_in { get => expires_in; set => expires_in = value; }
        [JsonProperty(PropertyName = "error")]
        public string Error { get => error; set => error = value; }
        [JsonProperty(PropertyName = "error_description")]
        public string Error_description { get => error_description; set => error_description = value; }
    }
}
