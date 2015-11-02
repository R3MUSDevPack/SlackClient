using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3MUS.Devpack.Slack
{
    public class ProfileData
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("skype")]
        public string SkypeName { get; set; }

        [JsonProperty("phone")]
        public string PhoneNumber { get; set; }

        [JsonProperty("fields")]
        public FieldData Fields { get; set; }

        [JsonProperty("real_name")]
        public string RealName { get; set; }

        [JsonProperty("real_name_normalized")]
        public string RealName_Normalized { get; set; }

        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        [JsonProperty("image_24")]
        public string Image24 { get; set; }

        [JsonProperty("image_32")]
        public string Image32 { get; set; }

        [JsonProperty("image_48")]
        public string Image48 { get; set; }

        [JsonProperty("image_72")]
        public string Image72 { get; set; }

        [JsonProperty("image_192")]
        public string Image192 { get; set; }

        [JsonProperty("image_512")]
        public string Image512 { get; set; }
    }
}

public class FieldData
{
    [JsonProperty("Xf0DAMP0TD")]
    public Field Field { get; set; }
}
public class Field
{
    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("alt")]
    public string Alt { get; set; }
}