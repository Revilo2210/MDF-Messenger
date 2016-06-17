using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    #region Message

    public class Message
    {
        public string Inhalt { get; set; }
        public SendeInformationen SendeInformationen { get; set; }
    }

    public class SendeInformationen
    {
        public string Sender { get; set; }
        public string Empaenger { get; set; }
        public DateTime SendeZeitpunkt { get; set; }
    }

    #endregion

    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
        }
        private List<Message> Messages { get; set; }
    }

    public class Contact
    {
        public string Username { get; set; }
        public string PublicKey { get; set; }
    }

    public static class Config
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string ServerName { get; set; }
        public static DateTime LastRefresh { get; set; }
    }
}