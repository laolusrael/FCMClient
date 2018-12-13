# FCMClient
Firebase Cloud Messaging Client for .NET

https://firebase.google.com/docs/cloud-messaging/


Firebase Cloud Messaging service allows developers to easily send push notifications to mobile application users. 
Ordinarily, you will have to write different code to implement push notifications for different mobile platforms, but Firebase Cloud Messaging allows you to send push notification to all platforms supported by your solution with a single api.


FCM Client for .net implements the FCM API using C#, thereby allowing anyone to send push notification with FCM easily.

FCM Client exposes only one method, PushAsync(), which contains friendly parameters and it is well documented. So, even my Grandmother can implement it.

To initialize an instance of the FCM Client, you need to first get an API key from Firebase console which will be passed as the only parameter to the Client() constructor.


Have fun!
