using FCMClient.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FCMClient.Interfaces
{
    public interface IClient
    {
        /// <summary>
        ///  Sends a regular push notification to device.
        /// </summary>
        /// <param name="deviceToken">Device token from Firebase</param>
        /// <param name="message">The push notification message</param>
        /// <param name="title">Title of the message</param>
        /// <returns></returns>
        Task PushAsync(string deviceToken, string message, string title = "GIGMS");
        /// <summary>
        /// Sends custom push notification to device
        /// </summary>
        /// <param name="deviceToken">Device token from Firebase</param>
        /// <param name="messageType">An enum used to determine how to send the push notification</param>
        /// <param name="payload">additional data to be delivered with the notification</param>
        /// <param name="message">push notification message</param>
        /// <param name="title">title of the message</param>
        /// <returns></returns>
        Task PushAsync(string deviceToken, NotificationType messageType, object payload, string message = "You have received a push notification", string title = "GIGMS");
    }
}
