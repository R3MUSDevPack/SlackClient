using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace R3MUS.Devpack.Slack
{
    /// <summary>
    /// This file is a container for the static methods involved in Slack
    /// </summary>
    public partial class Plugin
    {
        private static string url = "http://{0}.slack.com/api/";
        
        public static void SendToRoom(string message, string roomname, string token, string username)
        {
            try
            {
                Client client = new Client(token);
                client.PostMessage(message, username, string.Concat("#", roomname));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SendToRoom(MessagePayload payload, string roomname, string token, string username)
        {
            try
            {
                payload.Channel = string.Concat("#", roomname);
                payload.Username = username;

                Client client = new Client(token);
                client.PostMessage(payload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SendDirectMessage(string message, string username, string token)
        {
            try
            {
                Client client = new Client(token);
                client.PostMessage(message, "R3mus Bot", string.Concat("@", username));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void SendDirectMessage(MessagePayload payload, string username, string token)
        {
            try
            {
                payload.Channel = string.Concat("@", username);
                payload.Username = "R3mus Bot";

                Client client = new Client(token);
                client.PostMessage(payload);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static bool SendUserInvite(string groupName, string token, string userEmail)
        {
            var result = string.Empty;
            var localUrl = string.Concat(url, "users.admin.{3}?email={1}&token={2}&set_active=true&_attempts=1");

            string URI = string.Format(
                localUrl,
                groupName,
                userEmail,
                token,
                "invite"
                );
            using (WebClient client = new WebClient())
            {
                byte[] response = client.DownloadData(URI);
                result = Encoding.UTF8.GetString(response);
            }

            return result.Contains("\"ok\":true");
        }

        public static List<UserData> GetUsers(string groupName, string token)
        {
            var localUrl = string.Format(string.Concat(url, "users.list?&token={1}"), groupName, token);
            var responseString = string.Empty;

            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] response = client.DownloadData(localUrl);
                    responseString = Encoding.UTF8.GetString(response);
                }
                return JsonConvert.DeserializeObject<UserListResponse>(responseString).Members;
            }
            catch(Exception ex)
            {
                responseString = ex.Message;
                return new List<UserData>();
            }
        }

        public static bool DeactivateUser(string groupName, string token, string user)
        {
            var userId = Plugin.GetUsers(groupName, token).Where(usr => 
            (usr.Profile.EmailAddress == user)
            ||
            (usr.Name == user)
            ).FirstOrDefault().Id;
            var result = string.Empty;
            var localUrl = string.Concat(url, "users.admin.{3}?user={1}&token={2}&set_active=true&_attempts=1");

            string URI = string.Format(
                localUrl,
                groupName,
                userId,
                token,
                "setInactive"
                );
            using (WebClient client = new WebClient())
            {
                byte[] response = client.DownloadData(URI);
                result = Encoding.UTF8.GetString(response);
            }

            return result.Contains("\"ok\":true");
        }

        public static bool SetChannelTopic(string groupName, string channelName, string token, string newTopic)
        {
            var localUrl = string.Concat(url, "channels.setTopic?token={1}&channel={2}&topic={3}");
            var result = string.Empty;
            
            string URI = string.Format(
                localUrl,
                groupName,
                token,
                GetChannelId(groupName, channelName, token),
                newTopic,
                "setInactive"
                );

            using (WebClient client = new WebClient())
            {
                byte[] response = client.DownloadData(URI);
                result = Encoding.UTF8.GetString(response);
            }

            return result.Contains("\"ok\":true");
        }

        private static string GetChannelId(string groupName, string channelName, string token)
        {
            var localUrl = string.Concat(url, "channels.list?token={1}");
            var failResult = false.ToString();

            string URI = string.Format(
                localUrl,
                groupName,
                token
                );
            var channelListResponse = new ChannelListResponse();

            using (WebClient client = new WebClient())
            {
                byte[] response = client.DownloadData(URI);
                var strResponse = Encoding.UTF8.GetString(response);
                channelListResponse = (ChannelListResponse)JsonConvert.DeserializeObject<ChannelListResponse>(strResponse);
            }

            if(channelListResponse.Channels.ToList().Any(c => c.Name == channelName))
            {
                return channelListResponse.Channels.Where(c => c.Name == channelName).FirstOrDefault().Id;
            }
            else
            {
                return failResult;
            }
        }
    }
}
