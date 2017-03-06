﻿using System;
using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;

namespace PushXamarin.Droid
{

	[Service]
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class MyFirebaseMessagingService : FirebaseMessagingService
	{
		const string TAG = "MyFirebaseMsgService";
		public override void OnMessageReceived(RemoteMessage message)
		{
			Log.Debug(TAG, "From: " + message.From);
			Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
			if(message.GetNotification() != null)
				SendNotification(message.GetNotification().Body);
		}

		void SendNotification(string messageBody)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

			var notificationBuilder = new Notification.Builder(this)
			    .SetSmallIcon(Resource.Drawable.icon)
				.SetContentTitle("FCM Message")
				.SetContentText(messageBody)
				.SetAutoCancel(true)
				.SetContentIntent(pendingIntent);

			var notificationManager = NotificationManager.FromContext(this);
			notificationManager.Notify(0, notificationBuilder.Build());
		}
	}
}
