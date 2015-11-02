using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3MUS.Devpack.Slack
{
    public class UserData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("color")]
        public string Colour_HexValue { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }

        [JsonProperty("tz")]
        internal string Timezone_String { get; set; }

        [JsonProperty("tz_label")]
        public string Timezone { get; set; }

        [JsonProperty("tz_offset")]
        internal int TimezoneOffset { get; set; }

        [JsonProperty("profile")]
        public ProfileData Profile { get; set; }

        [JsonProperty("is_admin")]
        public bool Admin { get; set; }

        [JsonProperty("is_owner")]
        public bool Owner { get; set; }

        [JsonProperty("is_primary_owner")]
        public bool PrimaryOwner { get; set; }

        [JsonProperty("is_restricted")]
        public bool Restricted { get; set; }

        [JsonProperty("is_ultra_restricted")]
        public bool UltraRestricted { get; set; }

        [JsonProperty("is_bot")]
        public bool Bot { get; set; }

        [JsonProperty("has_files")]
        public bool HasFiles { get; set; }

        [JsonProperty("has_2fa")]
        public bool TwoFactorAuth { get; set; }
    }
}
