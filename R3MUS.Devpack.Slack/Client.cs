using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace R3MUS.Devpack.Slack
{
    internal class Client
    {
        private readonly Uri uri;
        private readonly Encoding encoding = new UTF8Encoding();

        internal Client(string urlWithAccessToken)
        {
            uri = new Uri(urlWithAccessToken);
        }

        //Post a message using simple strings
        internal void PostMessage(string v_Message, string v_Username = null, string v_Channel = null)
        {
            MessagePayload payload = new MessagePayload()
            {
                Channel = v_Channel,
                Username = v_Username,
                Text = v_Message
            };
            PostMessage(payload);
        }

        //Post a message using a Payload object
        internal void PostMessage(MessagePayload payload)
        {
            string payloadJson = JsonConvert.SerializeObject(payload);
            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;
                var response = client.UploadValues(uri, "POST", data);
                //The response text is usually "ok"
                string responseText = encoding.GetString(response);
            }
        }
    }
}
