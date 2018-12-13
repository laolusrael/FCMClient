using FCMClient.Interfaces;
using FCMClient.Types;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FCMClient.Impl
{
    public class Client:IClient
    {
        private readonly string _serverKey;
        private readonly string _endPoint;
        public Client(string serverKey)
        {
            _endPoint = "https://fcm.googleapis.com/fcm/send";
            _serverKey = serverKey;
        }

        public async Task PushAsync(string deviceToken, NotificationType messageType, object payload, string message = "You have received an alert", string title = "GIGMS")
        {
            if (string.IsNullOrEmpty(deviceToken))
                return;

            var pushMessage = new Message
            {
                content_available = true,
                priority = FcmMessagePriorityConstants.HIGH,
                to = deviceToken,
                notification = new Notification
                {
                    body = message,
                    title = title,
                },
                data = new Data
                {
                    body = payload,
                    title = title,
                    messageType = messageType
                }
            };

            await _SendAsync(pushMessage);

        }
        public async Task PushAsync(string deviceToken, string message, string title = "GIGMS")
        {
            if (string.IsNullOrEmpty(deviceToken) || string.IsNullOrEmpty(message))
                return;

            var pushMessage = new Message
            {
                to = deviceToken,
                notification = new Notification
                {
                    body = message,
                    title = title
                },
                data = new Data
                {
                    messageType = NotificationType.Normal,
                    title = title
                }
            };

            await _SendAsync(pushMessage);
        }

        private async Task _SendAsync(Message message)
        {

            if (message == null)
            {
                return;
            }



            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("Authorization", new System.Net.Http.Headers.AuthenticationHeaderValue("key", $"={_serverKey}").ToString());
                // Set up the content
                var jsonMessage = JsonConvert.SerializeObject(message);
                var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_endPoint, content);

                var cnt = await response.Content.ReadAsStringAsync();

                Debug.WriteLine("FCM Client // Firebase response");
                Debug.WriteLine(cnt);
            }
        }

    }
}
