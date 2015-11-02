using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3MUS.Devpack.Slack
{
    public class UserListResponse
    {
        [JsonProperty("ok")]
        public string GoodResponse { get; set; }

        [JsonProperty("members")]
        public List<UserData> Members { get; set; }
    }
}
