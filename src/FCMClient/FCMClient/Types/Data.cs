using System;
using System.Collections.Generic;
using System.Text;

namespace FCMClient.Types
{
    public class Data
    {
        public NotificationType messageType;
        public string title { get; set; }
        public object body { get; set; } // can be string or object based on NotificationType
    }
}
