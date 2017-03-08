using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3MUS.Devpack.Slack
{

    public class ChannelListResponse
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }
        [JsonProperty("channels")]
        public Channel[] Channels { get; set; }
    }

    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("created")]
        public int Created { get; set; }
        [JsonProperty("creator")]
        public string Creator { get; set; }
        [JsonProperty("is_archived")]
        public bool Archived { get; set; }
        [JsonProperty("is_member")]
        public bool Ismember { get; set; }
        [JsonProperty("num_members")]
        public int MemberCount { get; set; }
        [JsonProperty("topic")]
        public Topic Topic { get; set; }
        [JsonProperty("purpose")]
        public Purpose Purpose { get; set; }
    }

    public class Topic
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("creator")]
        public string Creator { get; set; }
        [JsonProperty("last_set")]
        public int LastSet { get; set; }
    }

    public class Purpose
    {
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("creator")]
        public string Creator { get; set; }
        [JsonProperty("last_set")]
        public int LastSet { get; set; }
    }

}
