using System;
using System.Collections.Generic;
using System.Text;

namespace FCMClient.Types
{
    public class Message
    {
        public bool content_available;
        public string priority;
        public string to;
        public Notification notification { get; set; }
        public Data data { get; set; }
    }
}
