using Newtonsoft.Json;
using System.Collections.Generic;

namespace R3MUS.Devpack.Slack
{
    public class MessagePayload
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public List<MessagePayloadAttachment> Attachments { get; set; }
    }
}
