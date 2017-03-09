using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.CloudMessaging;
using Firebase.InstanceID;
using Foundation;
using UIKit;
using UserNotifications;

namespace PushXamarin.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUNUserNotificationCenterDelegate, IMessagingDelegate
	{
		public event EventHandler<UserInfoEventArgs> NotificationReceived = (sender, e) => { 
			Console.WriteLine($"NotificationReceived: {e.ToString()}");
		};

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());


			// Monitor token generation
			InstanceId.Notifications.ObserveTokenRefresh(TokenRefreshNotification);

			// Register your app for remote notifications.
			if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
			{
				// iOS 10 or later
				var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
				UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) =>
				{
					Console.WriteLine(granted);
				});

				// For iOS 10 display notification (sent via APNS)
				//UNUserNotificationCenter.Current.Delegate = this;

				// For iOS 10 data message (sent via FCM)
				//Messaging.SharedInstance.RemoteMessageDelegate = this;
			}
			else
			{
				// iOS 9 or before
				var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
				var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
				UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
			}

			UIApplication.SharedApplication.RegisterForRemoteNotifications();

			Firebase.Analytics.App.Configure();

			try
			{
				var token = InstanceId.SharedInstance.Token;
				Console.WriteLine($"Token: {token}");
				ConnectToFCM(Window);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return base.FinishedLaunching(app, options);
		}


		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
			//Messaging.SharedInstance.Disconnect();
			Console.WriteLine("Disconnected from FCM");
		}

		public override void WillEnterForeground(UIApplication application)
		{
			//ConnectToFCM (Window.RootViewController);
		}



		// To receive notifications in foregroung on iOS 9 and below.
		// To receive notifications in background in any iOS version
		public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			// If you are receiving a notification message while your app is in the background,
			// this callback will not be fired 'till the user taps on the notification launching the application.

			// If you disable method swizzling, you'll need to call this method. 
			// This lets FCM track message delivery and analytics, which is performed
			// automatically with method swizzling enabled.
			Console.WriteLine("DidReceiveRemoteNotification");
			Messaging.SharedInstance.AppDidReceiveMessage (userInfo);

			if (NotificationReceived == null)
				return;

			var e = new UserInfoEventArgs { UserInfo = userInfo };
			NotificationReceived(this, e);
		}

		// You'll need this method if you set "FirebaseAppDelegateProxyEnabled": NO in GoogleService-Info.plist
		//public override void RegisteredForRemoteNotifications (UIApplication application, NSData deviceToken)
		//{
		//	InstanceId.SharedInstance.SetApnsToken (deviceToken, ApnsTokenType.Sandbox);
		//}

		// To receive notifications in foreground on iOS 10 devices.
		[Export("userNotificationCenter:willPresentNotification:withCompletionHandler:")]
		public void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
		{
			Console.WriteLine("WillPresentNotification");
			if (NotificationReceived == null)
				return;

			var e = new UserInfoEventArgs { UserInfo = notification.Request.Content.UserInfo };
			NotificationReceived(this, e);
		}

		// Receive data message on iOS 10 devices.
		public void ApplicationReceivedRemoteMessage(RemoteMessage remoteMessage)
		{
			Console.WriteLine(remoteMessage.AppData);
		}

		//////////////////
		////////////////// WORKAROUND
		//////////////////

		#region Workaround for handling notifications in background for iOS 10

		[Export("userNotificationCenter:didReceiveNotificationResponse:withCompletionHandler:")]
		public void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
		{

			Console.WriteLine("DidReceiveNotificationResponse");
			if (NotificationReceived == null)
				return;

			var e = new UserInfoEventArgs { UserInfo = response.Notification.Request.Content.UserInfo };
			NotificationReceived(this, e);
		}



		#endregion

		//////////////////
		////////////////// END OF WORKAROUND
		//////////////////
		/// 
		void TokenRefreshNotification(object sender, NSNotificationEventArgs e)
		{
			// This method will be fired everytime a new token is generated, including the first
			// time. So if you need to retrieve the token as soon as it is available this is where that
			// should be done.
			//var refreshedToken = InstanceId.SharedInstance.Token;


			ConnectToFCM(Window);

			// TODO: If necessary send token to application server.
		}

		public static void ConnectToFCM(UIWindow window)
		{
			Messaging.SharedInstance.Connect(error =>
			{
				if (error != null)
				{
					ShowMessage("Unable to connect to FCM", error.LocalizedDescription,null,window);
				}
				else
				{
					ShowMessage("Success!", "Connected to FCM",null,window);
					Console.WriteLine($"Token: {InstanceId.SharedInstance.Token}",window);
				}
			});
		}


		public static void ShowMessage(string title, string message, Action actionForOk = null,UIWindow window=null)
		{
			if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
			{
				var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
				alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (obj) =>
				{
					if (actionForOk != null)
					{
						actionForOk();
					}
				}));
				window.RootViewController.PresentViewController(alert, true, null);
			}
			else
			{
				new UIAlertView(title, message, null, "Ok", null).Show();
			}
		}



	}
}
