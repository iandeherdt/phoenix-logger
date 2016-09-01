using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoenixLogger.Utils
{
    public class PushData
    {
        [JsonProperty("topic")]
        public string Topic { get; set; } = "";
        [JsonProperty("event")]
        public string Event { get; set; } = "";
        [JsonProperty("payload")]
        public dynamic Payload { get; set; }
        [JsonProperty("ref")]
        public string Ref { get; set; } = null;

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static PushData Deserialize(string rawMessage)
        {
            return JsonConvert.DeserializeObject<PushData>(rawMessage);
        }

        public override string ToString()
        {
            return Serialize();
        }
    }
}
