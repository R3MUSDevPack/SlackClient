using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3MUS.Devpack.Slack
{
    public class Plugin
    {
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
    }
}
