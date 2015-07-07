using System;
using Xamarin.Forms;
using AI.XamarinSDK;

#if __ANDROID__
using Android;
#endif

namespace XamarinTest
{
	public class App : Application
	{
		public App ()
		{
			var mainNav = new NavigationPage (new XamarinTestMasterView ());
			MainPage = mainNav;
		}

		protected override void OnStart ()
		{
			#if __IOS__

			ApplicationInsights.Setup ("<YOUR_IKEY_HERE>");
			ApplicationInsights.Start ();

			#elif __ANDROID__

			Android.App.Application app = ((Android.App.Activity)Forms.Context).Application;
			ApplicationInsights.Setup (Android.App.Application.Context, app, "<YOUR_IKEY_HERE>");
			ApplicationInsights.Start ();

			#endif
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

